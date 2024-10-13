using ClosedXML.Excel;
using System.Data;

namespace ExcelLibrary;

// Use NPOI if another formats needed.
public class ExcelCore
{
    public static void CreateExcel(string fileName, DataTable data)
    {
        using XLWorkbook workbook = new();
        IXLWorksheet worksheet = workbook.AddWorksheet();

        worksheet.Cell("A1").InsertData(data);

        workbook.SaveAs(fileName);
    }

    public static void CreateExcel<T>(string fileName, DataTable data, List<T> headers)
    where T : notnull
    {
        using XLWorkbook workbook = new();

        IXLWorksheet worksheet = workbook.AddWorksheet();
        char[] alpha = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();

        foreach (var item in alpha.Select((value, index) => new{index, value}))
        {
            worksheet.Cell($"{item.value}{item.index}").InsertData(headers);
        }

        worksheet.Cell("A2").InsertData(data);
        workbook.SaveAs(fileName);
    }

    public static void CreateExcel(string sheetName, string fileName, DataTable data, XLColor tabColor)
    {
        using XLWorkbook workbook = new();

        IXLWorksheet worksheet = workbook.AddWorksheet(sheetName).SetTabColor(tabColor);
        // it is inserted?
        var datain = worksheet.Cell("A1").InsertData(data);
        workbook.SaveAs(fileName);
    }
}
