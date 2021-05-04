using System;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using LiteDB;
using Serilog;
using Simplexcel;

namespace SUT
{
    static class ReportingExcel
    {
        public static void CreateWeeklyReport(int year, int weekNumber)
        {
            try
            {
                Log.Debug("Generating Weekly Report.");
                // Prepare Timesheet Template
                var sheet = new Worksheet(string.Format("Timesheet", year, weekNumber));
                SetTitleCell(sheet, "A2", "Weekly Timesheet");
                sheet.ColumnWidths[0] = 30;
                SetHeadingCell(sheet, "B1", "Year");
                SetBodyCell(sheet, "B2", year);
                SetHeadingCell(sheet, "C1", "Week");
                SetBodyCell(sheet, "C2", weekNumber);
                sheet.ColumnWidths[1] = 10;
                SetHeadingCell(sheet, "B4", "Morning");
                sheet.ColumnWidths[2] = 10;
                SetHeadingCell(sheet, "C4", "Afternoon");
                sheet.ColumnWidths[3] = 10;
                SetHeadingCell(sheet, "D4", "Evening");
                sheet.ColumnWidths[4] = 10;
                SetHeadingCell(sheet, "E4", "Night");
                sheet.ColumnWidths[5] = 15;
                SetHeadingCell(sheet, "F4", "Day Total");
                sheet.ColumnWidths[6] = 15;
                SetHeadingCell(sheet, "G4", "Day Total Hours");
                Log.Debug("Primary headings set.");

                // Add Data
                var dateOfDayBeingReportedOn = FirstDateOfWeekISO8601(year, weekNumber);
                Log.Debug("Identified date for Monday.");
                SetHeadingCell(sheet, "A5", string.Format("{0} - Monday", dateOfDayBeingReportedOn.ToString("MMMM dd, yyyy")));
                PopulateCellsWithWorkingDayData(sheet, dateOfDayBeingReportedOn, 5);
                Log.Debug("Monday's data generated.");
                dateOfDayBeingReportedOn = dateOfDayBeingReportedOn.AddDays(1);
                SetHeadingCell(sheet, "A6", string.Format("{0} - Tuesday", dateOfDayBeingReportedOn.ToString("MMMM dd, yyyy")));
                PopulateCellsWithWorkingDayData(sheet, dateOfDayBeingReportedOn, 6);
                Log.Debug("Tuesday's data generated.");
                dateOfDayBeingReportedOn = dateOfDayBeingReportedOn.AddDays(1);
                SetHeadingCell(sheet, "A7", string.Format("{0} - Wednesday", dateOfDayBeingReportedOn.ToString("MMMM dd, yyyy")));
                PopulateCellsWithWorkingDayData(sheet, dateOfDayBeingReportedOn, 7);
                Log.Debug("Wednesday's data generated.");
                dateOfDayBeingReportedOn = dateOfDayBeingReportedOn.AddDays(1);
                SetHeadingCell(sheet, "A8", string.Format("{0} - Thursday", dateOfDayBeingReportedOn.ToString("MMMM dd, yyyy")));
                PopulateCellsWithWorkingDayData(sheet, dateOfDayBeingReportedOn, 8);
                Log.Debug("Thursday's data generated.");
                dateOfDayBeingReportedOn = dateOfDayBeingReportedOn.AddDays(1);
                SetHeadingCell(sheet, "A9", string.Format("{0} - Friday", dateOfDayBeingReportedOn.ToString("MMMM dd, yyyy")));
                PopulateCellsWithWorkingDayData(sheet, dateOfDayBeingReportedOn, 9);
                Log.Debug("Friday's data generated.");
                dateOfDayBeingReportedOn = dateOfDayBeingReportedOn.AddDays(1);
                SetHeadingCell(sheet, "A10", string.Format("{0} - Saturday", dateOfDayBeingReportedOn.ToString("MMMM dd, yyyy")));
                PopulateCellsWithWorkingDayData(sheet, dateOfDayBeingReportedOn, 10);
                Log.Debug("Saturday's data generated.");
                dateOfDayBeingReportedOn = dateOfDayBeingReportedOn.AddDays(1);
                SetHeadingCell(sheet, "A11", string.Format("{0} - Sunday", dateOfDayBeingReportedOn.ToString("MMMM dd, yyyy")));
                PopulateCellsWithWorkingDayData(sheet, dateOfDayBeingReportedOn, 11);
                Log.Debug("Sunday's data generated.");

                SetHeadingCell(sheet, "F13", "Week Total");
                SetBodyCellFormula(sheet, "F14", "=SUM(F5:F11)");
                SetHeadingCell(sheet, "G13", "Week Total Hours");
                SetBodyCellFormula(sheet, "G14", "=SUM(G5:G11)");
                Log.Debug("Formulas for caluclating weekly totals added.");

                var workbook = new Workbook();
                workbook.Title = string.Format("{0}-{1}-{2}-alpha", year, weekNumber, Application.ProductVersion);
                workbook.Author = string.Format("{0}-{1}", Application.ProductName, Application.ProductVersion);
                Log.Debug("Workbook instantiated with title and author set.");
                workbook.Add(sheet);
                Log.Debug("Sheet added to workbook.");

#if DEBUG
                workbook.Save(string.Format(@"{0}\SUT-Timesheet-Test-{1}{2}.xlsx", @"C:\temp", year, weekNumber));
#else
                workbook.Save (string.Format (@"{0}\SUT-Timesheet-{1}{2}.xlsx", Environment.GetFolderPath (Environment.SpecialFolder.MyDocuments), year, weekNumber));
#endif
            }
            catch (IOException)
            {
                var result = MessageBox.Show("The file may be open in another application if the report has been generated before.\n\nControlled Folder Access may be blocking the saving of the report.", "SUT - Report could not be save!", MessageBoxButtons.RetryCancel, MessageBoxIcon.Exclamation);
                
                if (result == DialogResult.Retry)
                {
                    CreateWeeklyReport(year, weekNumber);
                }
            }
            catch (Exception exception)
            {
#if DEBUG
                throw exception;
#else
                Log.Fatal (exception, "Weekly report generation failed.");
                Application.Exit ();
#endif
            }
        }

        private static void PopulateCellsWithWorkingDayData(Worksheet sheet, DateTime dateTimeOfWorkingDay, int rowNumber)
        {
            try
            {
#if DEBUG
                // Open database (or create if doesn't exist)
                using (var db = new LiteDatabase(@"C:\temp\sut-test.db"))
#else
                // Open database (or create if doesn't exist)
                using (var db = new LiteDatabase ("sut.db"))
#endif
                {
                    // Get a collection (or create, if doesn't exist)
                    var databaseCollection = db.GetCollection<WorkingDay>("WorkingDays");

                    var persistedWorkingDay = databaseCollection.FindOne(x => x.Id == dateTimeOfWorkingDay.ToString("yyyyMMdd"));
                    if (persistedWorkingDay != null)
                    {
                        SetBodyCell(sheet, string.Format("B{0}", rowNumber), persistedWorkingDay.TotalServiceUnitsMorning);
                        SetBodyCell(sheet, string.Format("C{0}", rowNumber), persistedWorkingDay.TotalServiceUnitsAfternoon);
                        SetBodyCell(sheet, string.Format("D{0}", rowNumber), persistedWorkingDay.TotalServiceUnitsEvening);
                        SetBodyCell(sheet, string.Format("E{0}", rowNumber), persistedWorkingDay.TotalServiceUnitsNight);
                        SetBodyCellFormula(sheet, string.Format("F{0}", rowNumber), string.Format(@"=SUM(B{0}:E{0})", rowNumber));
                        SetBodyCellFormula(sheet, string.Format("G{0}", rowNumber), string.Format(@"=CONVERT((F{0}*{1}),""mn"",""hr"")", rowNumber, persistedWorkingDay.OneServiceUnitInMinutes));
                    }
                    else
                    {
                        SetBodyCell(sheet, string.Format("B{0}", rowNumber), 0);
                        SetBodyCell(sheet, string.Format("C{0}", rowNumber), 0);
                        SetBodyCell(sheet, string.Format("D{0}", rowNumber), 0);
                        SetBodyCell(sheet, string.Format("E{0}", rowNumber), 0);
                        var workingDay = new WorkingDay();
                        SetBodyCellFormula(sheet, string.Format("F{0}", rowNumber), string.Format(@"=SUM(B{0}:E{0})", rowNumber),true);
                        SetBodyCellFormula(sheet, string.Format("G{0}", rowNumber), string.Format(@"=CONVERT((F{0}*{1}),""mn"",""hr"")", rowNumber, workingDay.OneServiceUnitInMinutes), true);
                    }
                }
            }
            catch (Exception exception)
            {
#if DEBUG
                throw exception;
#else
                Log.Fatal (exception, "Populate cells failed.");
                Application.Exit ();
#endif
            }
        }

        private static void SetTitleCell(Worksheet sheet, string cell, string title)
        {
            sheet.Cells[cell] = title;
            sheet.Cells[cell].Bold = true;
            sheet.Cells[cell].FontSize = 18;
        }
        private static void SetHeadingCell(Worksheet sheet, string cell, string heading)
        {
            sheet.Cells[cell] = heading;
            sheet.Cells[cell].Bold = true;
        }
        private static void SetBodyCell(Worksheet sheet, string cell, string content)
        {
            sheet.Cells[cell] = content;
        }

        private static void SetBodyCell(Worksheet sheet, string cell, int content)
        {
            sheet.Cells[cell] = content;
            if (content == 0)
                sheet.Cells[cell].TextColor = Color.DarkGray;
        }

        private static void SetBodyCell(Worksheet sheet, string cell, DateTime content)
        {
            sheet.Cells[cell] = content;
        }

        private static void SetBodyCellFormula(Worksheet sheet, string cell, string formula)
        {
            sheet.Cells[cell] = Cell.Formula(formula);
        }
        private static void SetBodyCellFormula(Worksheet sheet, string cell, string formula, bool predictedValueWillBeZero)
        {
            sheet.Cells[cell] = Cell.Formula(formula);

            if (predictedValueWillBeZero)
                sheet.Cells[cell].TextColor = Color.DarkGray;
        }

        // This presumes that weeks start with Monday.
        // Week 1 is the 1st week of the year with a Thursday in it.
        public static int GetIso8601WeekOfYear(DateTime time)
        {
            DayOfWeek day = CultureInfo.InvariantCulture.Calendar.GetDayOfWeek(time);
            if (day >= DayOfWeek.Monday && day <= DayOfWeek.Wednesday)
            {
                time = time.AddDays(3);
            }

            // Return the week of our adjusted day
            return CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(time, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
        }

        private static DateTime FirstDateOfWeekISO8601(int year, int weekOfYear)
        {
            DateTime jan1 = new DateTime(year, 1, 1);
            int daysOffset = DayOfWeek.Thursday - jan1.DayOfWeek;

            // Use first Thursday in January to get first week of the year as
            // it will never be in Week 52/53
            DateTime firstThursday = jan1.AddDays(daysOffset);
            var cal = CultureInfo.CurrentCulture.Calendar;
            int firstWeek = cal.GetWeekOfYear(firstThursday, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);

            var weekNum = weekOfYear;
            // As we're adding days to a date in Week 1,
            // we need to subtract 1 in order to get the right date for week #1
            if (firstWeek == 1)
            {
                weekNum -= 1;
            }

            // Using the first Thursday as starting week ensures that we are starting in the right year
            // then we add number of weeks multiplied with days
            var result = firstThursday.AddDays(weekNum * 7);

            // Subtract 3 days from Thursday to get Monday, which is the first weekday in ISO8601
            return result.AddDays(-3);
        }
    }
}