using UglyToad.PdfPig;
using UglyToad.PdfPig.Content;
using UglyToad.PdfPig.Core;
using UglyToad.PdfPig.Fonts.Standard14Fonts;
using UglyToad.PdfPig.Writer;

namespace PDFLibrary;

public class PDFCore
{
    public static List<string> GetListOfTextFromPDF(string pdfLocation)
    {
        List<string> pdfText = new();

        using (PdfDocument document = PdfDocument.Open(pdfLocation))
        {
            if (document != null)
            {
                foreach (Page page in document.GetPages())
                {
                    string pageText = page.Text;

                    foreach (Word word in page.GetWords())
                    {
                        pdfText.Add(word.Text);
                    }
                }
            }
        }

        return pdfText;
    }

    public static void CreatePDFDocument(PageSize pageSize, string text, int fontSize, string saveLocation)
    {
        PdfDocumentBuilder builder = new();
        PdfPageBuilder page = builder.AddPage(pageSize);
        PdfDocumentBuilder.AddedFont font = builder.AddStandard14Font(Standard14Font.Helvetica);

        if (text is not null && text != String.Empty) 
        { 
            page.AddText(text, fontSize, new PdfPoint(25, 700), font);
        }

        byte[] documentBytes = builder.Build();

        File.WriteAllBytes(saveLocation, documentBytes);
    }
}
