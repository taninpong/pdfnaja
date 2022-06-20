using System;
using SkiaSharp;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf.Interactive;
using System.Threading.Tasks;
using Syncfusion.Drawing;
using System.IO;
using docsau = SautinSoft.Document;
using SautinSoft.Document;
using Color = SautinSoft.Document.Color;
using SautinSoft.Document.Drawing;
using System.Text;
using Syncfusion.Pdf.Tables;
using System.Data;
using System.Collections.Generic;
using Syncfusion.Pdf.Grid;
using Syncfusion.Pdf.Security;

namespace pdf
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            //GenSynPDFA3();
            Multipage2();
            //PDFSautin(fs);
            Console.WriteLine("Hello World!");
        }

        public static void LoadAndSaveAsPDFA()
        {
            // Path to a loadable document.
            string loadPath = @"example.docx";
            DocumentCore dc = DocumentCore.Load(loadPath);

            PdfSaveOptions options = new PdfSaveOptions()
            {
                // PdfComliance supports: PDF/A, PDF/1.5, etc.
                Compliance = PdfCompliance.PDF_A3a,


            };
            //dc.('Input.xml');
            string savePath = Path.ChangeExtension(loadPath, ".pdf");
            dc.Save(savePath, options);
            //  PdfDocument pdf = new PdfDocument("example.pdf");
            //pdf.LoadFromFile("example.pdf");
            //   PdfAttachment attachment = pdf.Attachments.Add("Input.xml");
            //  File.WriteAllBytes(attachment.FileName, attachment.Data);
            // Open the result for demonstration purposes.
            //System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(savePath) { UseShellExecute = true });
        }

        public static void GenSynPDFA3()
        {
            PdfDocument document = new PdfDocument(PdfConformanceLevel.Pdf_A3A);

            var page = document.Pages.Add();
            //document.Pages.Add();
            //var page3 = document.Pages.Add();
            //var page4 = document.Pages.Add();
            PdfGraphics graphics = page.Graphics;
            Stream fileStream = new FileStream("F:\\pilot\\pdfSyncfusion\\pdf\\pdf\\bin\\Debug\\net5.0\\Input.xml", FileMode.Open, FileAccess.Read);
            PdfAttachment attachment = new PdfAttachment("F:\\pilot\\pdfSyncfusion\\pdf\\pdf\\bin\\Debug\\net5.0\\Input.xml", fileStream);
            attachment.Relationship = PdfAttachmentRelationship.Alternative;
            attachment.ModificationDate = DateTime.Now;
            document.Attachments.Add(attachment);
            FileStream fontStream = new FileStream("tahoma.ttf", FileMode.Open, FileAccess.Read);
            PdfFont font = new PdfTrueTypeFont(fontStream, 18);

            //Draw the text
            var text = "Hi! เอกสาร PDF มีการใช้อย่างแพร่หลายเป็นเวลาหลายปีและนับสิบ ๆ แถมฟรี ผู้อ่านPDF เชิงพาณิชย์บรรณาธิการและห้องสมุดพร้อมใช้งาน อย่างไรก็ตามแม้จะมีความนิยมนี้ก็ยังคงยากที่จะหาคำแนะนำกระชับรูปแบบ PDF พื้นเมืองการทำความเข้าใจการทำงานภายในของ PDF ทำให้สามารถสร้างได้แบบไดนามิกเอกสาร PDF ตัวอย่างเช่นเว็บเซิร์ฟเวอร์สามารถดึงข้อมูลจากฐานข้อมูลใช้เพื่อกำหนดใบกำกับสินค้าและให้บริการกับลูกค้าได้ทันที Hello World!!! A  สวัสดีชาวโลก  ยินดีที่ได้รู้จัก B";
            var text2 = @"Why do we use it? It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout.The point of using Lorem Ipsum is that it has a more - or - less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English. Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy.Various versions have evolved over the years, sometimes by accident, sometimes on purpose(injected humour and the like). 举个例子呢? 就说我的好朋友吧。失去了他们的胳膊,";
            var result = text + text2 + text2 + text;
            PdfStringFormat format = new PdfStringFormat();
            graphics.DrawString(result, font, PdfBrushes.Black, new RectangleF(0, 55, page.GetClientSize().Width, page.GetClientSize().Height), format);

            //Draw the image
            FileStream imageStream = new FileStream("icon.png", FileMode.Open, FileAccess.Read);
            PdfBitmap image = new PdfBitmap(imageStream);
            graphics.DrawImage(image, new PointF(200, 0), new SizeF(50, 50));

            MemoryStream stream = new MemoryStream();
            ////Save the document into memory stream
            document.Save(stream);
            stream.Position = 0;
            document.Close(true);
            File.WriteAllBytes("SampleSyn.pdf", stream.ToArray());

        }

        public static void Xs()
        {
            //Create a new PDF document
            PdfDocument document = new PdfDocument();

            ////    PdfDocument documentsau = new PdfDocument(PdfConformanceLevel.Pdf_A3A);
            //Add a page to the document
            PdfPage page = document.Pages.Add();

            //Create PDF graphics for the page
            PdfGraphics graphics = page.Graphics;
            //Set the standard font
            PdfFont font = new PdfStandardFont(PdfFontFamily.ZapfDingbats, 20);
            MemoryStream stream = new MemoryStream();
            string fontName = font.Name;
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("Font Name: " + fontName);
            //Draw the text
            graphics.DrawString("หกดฟหด สวัสดีครับ นะจ๊ะ AAAA", font, PdfBrushes.Black, new PointF(0, 0));
            FileStream imageStream = new FileStream("icon.png", FileMode.Open, FileAccess.Read);

            PdfBitmap image = new PdfBitmap(imageStream);

            //Draw the image

            graphics.DrawImage(image, new PointF(5, 5), new SizeF(50, 50));
            //var fileText = File.ReadAllText(@"path\to\my\file.txt");
            byte[] bytes = System.IO.File.ReadAllBytes("F:\\pilot\\pdfSyncfusion\\pdf\\pdf\\bin\\Debug\\net5.0\\Input.xml");
            var fs = new FileStream("F:\\pilot\\pdfSyncfusion\\pdf\\pdf\\bin\\Debug\\net5.0\\Input.xml", FileMode.Open, FileAccess.Read);
            var sr = new StreamReader(fs, Encoding.UTF8);
            string content = sr.ReadToEnd();
            //Console.WriteLine(content);


            //Creates an attachment
            var attachment = new PdfAttachment("F:\\pilot\\pdfSyncfusion\\pdf\\pdf\\bin\\Debug\\net5.0\\Input.xml", bytes);
            attachment.ModificationDate = DateTime.Now;
            attachment.Description = "Input.xml";
            //attachment.MimeType = "application/txt";

            //Adds the attachment to the document
            document.Attachments.Add(attachment);
            //Saving the PDF to the MemoryStream

            document.Save(stream);

            //Set the position as '0'.
            stream.Position = 0;

            File.WriteAllBytes("Samuple.pdf", stream.ToArray());
        }

        public static void PDFSautin(Stream data)
        {
            // Set a path to our document.
            string docPath = @"Result-DocumentBuilder.pdf";

            // Create a new document and DocumentBuilder.
            DocumentCore dc = new DocumentCore();
            DocumentBuilder db = new DocumentBuilder(dc);

            // Set page size A4.
            Section section = db.Document.Sections[0];
            section.PageSetup.PaperType = PaperType.A4;

            // Add 1st paragraph with formatted text.
            db.CharacterFormat.FontName = "Verdana";
            db.CharacterFormat.Size = 16;
            db.CharacterFormat.FontColor = Color.Orange;
            db.Write("This is a first line in 1st paragraph!");
            // Add a line break into the 1st paragraph.
            db.InsertSpecialCharacter(SpecialCharacterType.LineBreak);
            // Add 2nd line to the 1st paragraph, create 2nd paragraph.
            db.Writeln("Let's type a second line.");
            // Specify the paragraph alignment.
            (section.Blocks[0] as Paragraph).ParagraphFormat.Alignment = HorizontalAlignment.Center;

            // Add text into the 2nd paragraph.
            db.CharacterFormat.ClearFormatting();
            db.CharacterFormat.Size = 25;
            db.CharacterFormat.FontColor = Color.Blue;
            db.CharacterFormat.Bold = true;
            db.Write("This is a first line in 2nd paragraph.");
            // Insert a line break into the 2nd paragraph.
            db.InsertSpecialCharacter(SpecialCharacterType.LineBreak);
            // Insert 2nd line with own formatting to the 2nd paragraph.
            db.CharacterFormat.Size = 20;
            db.CharacterFormat.FontColor = Color.DarkGreen;
            db.CharacterFormat.UnderlineStyle = UnderlineType.Single;
            db.CharacterFormat.Bold = false;
            db.Write("This is a second line.");

            // Add a graphics figure into the paragraph.
            db.CharacterFormat.ClearFormatting();
            Shape shape = db.InsertShape(SautinSoft.Document.Drawing.Figure.SmileyFace, new SautinSoft.Document.Drawing.Size(50, 50, LengthUnit.Millimeter));
            // Specify outline and fill.
            shape.Outline.Fill.SetSolid(new SautinSoft.Document.Color("#358CCB"));
            shape.Outline.Width = 3;
            shape.Fill.SetSolid(SautinSoft.Document.Color.Orange);

            // Save the document to the file in PDF format.
            dc.Save(docPath, new PdfSaveOptions()
            { Compliance = PdfCompliance.PDF_A3a, });

            // Open the result for demonstration purposes.
            //System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(docPath) { UseShellExecute = true });
        }

        public static void Multipage()
        {
            //Create a new PDF document.
            PdfDocument document = new PdfDocument(PdfConformanceLevel.Pdf_A3A);
            //Add the event.
            document.Pages.PageAdded += new PageAddedEventHandler(Pages_PageAdded);
            //Create a new page and add it as the last page of the document.
            PdfPage page = document.Pages.Add();
            PdfGraphics graphics = page.Graphics;
            document.DocumentInformation.CreationDate = DateTime.Now;
            document.DocumentInformation.Creator = "มานะ2018";

            //Read the long text from the text file.
            //StreamReader reader = new StreamReader(@"input.txt", Encoding.ASCII);
            //string text = reader.ReadToEnd();
            //reader.Close();
            Stream fileStream = new FileStream("F:\\pilot\\pdfSyncfusion\\pdf\\pdf\\bin\\Debug\\net5.0\\Input.xml", FileMode.Open, FileAccess.Read);
            PdfAttachment attachment = new PdfAttachment("F:\\pilot\\pdfSyncfusion\\pdf\\pdf\\bin\\Debug\\net5.0\\Input.xml", fileStream);
            attachment.Relationship = PdfAttachmentRelationship.Alternative;
            attachment.ModificationDate = DateTime.Now;
            attachment.CreationDate = DateTime.Now;
            document.Attachments.Add(attachment);
            FileStream fontStream = new FileStream("Kanit-Light.ttf", FileMode.Open, FileAccess.Read);
            PdfFont font = new PdfTrueTypeFont(fontStream, true, PdfFontStyle.Regular, 16);

            var text = "Hi! เอกสาร PDF มีการใช้อย่างแพร่หลายเป็นเวลาหลายปีและนับสิบ ๆ แถมฟรี ผู้อ่านPDF " +
                "เชิงพาณิชย์บรรณาธิการและห้องสมุดพร้อมใช้งาน อย่างไรก็ตามแม้จะมีความนิยมนี้ก็ยังคงยากที่จะหาคำแนะนำกระชับรูปแบบ PDF " +
                "พื้นเมืองการทำความเข้าใจการทำงานภายในของ PDF ทำให้สามารถสร้างได้แบบไดนามิกเอกสาร PDF " +
                "ตัวอย่างเช่นเว็บเซิร์ฟเวอร์สามารถดึงข้อมูลจากฐานข้อมูลใช้เพื่อกำหนดใบกำกับสินค้าและให้บริการกับลูกค้าได้ทันที Hello World!!! A  สวัสดีชาวโลก  ยินดีที่ได้รู้จัก B";
            var text2 = @"Why do we use it? It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout.The point of using Lorem Ipsum is that it has a more - or - less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English. Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy.Various versions have evolved over the years, sometimes by accident, sometimes on purpose(injected humour and the like).";
            var resulttext = text + text2 + "012345678901263456789,๑๒๓๔๕๖๗๘๙๐";
            //Create a text element with the text and font.
            PdfStringFormat format = new PdfStringFormat();
            format.ComplexScript = true;
            PdfTextElement textElement = new PdfTextElement(resulttext, font, null, null, format);
            PdfLayoutFormat layoutFormat = new PdfLayoutFormat();
            layoutFormat.Layout = PdfLayoutType.Paginate;
            //layoutFormat.Break = PdfLayoutBreakType.FitPage;
            format.EnableBaseline = true;
            //Img
            FileStream imageStream = new FileStream("icon.png", FileMode.Open, FileAccess.Read);
            PdfBitmap image = new PdfBitmap(imageStream);
            graphics.DrawImage(image, new PointF(200, 0), new SizeF(50, 50));
            //Draw the first paragraph.
            //PdfLayoutResult result = textElement.Draw(page, new RectangleF(0, 0, page.GetClientSize().Width, page.GetClientSize().Height), layoutFormat);

            ////Signature
            FileStream certificateStream = new FileStream("certificatedemo.pfx", FileMode.Open, FileAccess.Read);

            PdfCertificate pdfCert = new PdfCertificate(certificateStream, "P@ssw0rd1234");
            PdfSignature signature = new PdfSignature(document, page, pdfCert, "Signature");

            //Sets an image for signature field 

            FileStream signatureimageStream = new FileStream("icon.png", FileMode.Open, FileAccess.Read);
            PdfBitmap signatureImage = new PdfBitmap(signatureimageStream);

            //Timestam
            signature.TimeStampServer = new TimeStampServer(new Uri("http://syncfusion.digistamp.com"));
            signature.Bounds = new RectangleF(new PointF(0, 0), signatureImage.PhysicalDimension);
            signature.ContactInfo = "johndoe@owned.us";

            signature.LocationInfo = "Honolulu, Hawaii";

            signature.Reason = "I am author of this document.";

            //Draws the signature image
            //signature.TimeStampServer = new TimeStampServer(new Uri("http://syncfusion.digistamp.com"), "user", "123456");
            graphics.DrawImage(signatureImage, 0, 0);
            //==============================

            //table
            //Create a new PDF light table
            PdfLightTable table = new PdfLightTable();

            //Create IEnumerable custom object
            List<Customer> customerDetails = new List<Customer>();

            for (int i = 0; i < 6; i++)
            {
                Customer customer = new Customer();
                customer.ID = i;
                customer.Name = "ABC";
                customer.Age = 26;
                customerDetails.Add(customer);
            }

            //Enable the table header
            table.Style.ShowHeader = true;

            //Set the custom object as table data source
            table.DataSource = customerDetails;

            table.Style.CellPadding = 2;

            //Create a new PdfCellStyle instance
            PdfCellStyle headerStyle = new PdfCellStyle();

            //Assign font
            //headerStyle.Font = new PdfStandardFont(PdfFontFamily.Helvetica, 10, PdfFontStyle.Bold);
            headerStyle.Font = font;
            //Set alignment
            headerStyle.StringFormat = new PdfStringFormat(PdfTextAlignment.Center);

            //Set header style.
            table.Style.HeaderStyle = headerStyle;

            //Create new PdfCellStyle instance
            PdfCellStyle cellStyle = new PdfCellStyle();

            //Set font 
            //cellStyle.Font = new PdfStandardFont(PdfFontFamily.Helvetica, 10, PdfFontStyle.Regular);
            cellStyle.Font = font;
            //Set alignment
            cellStyle.StringFormat = new PdfStringFormat(PdfTextAlignment.Center);

            //Set default cell style
            table.Style.DefaultStyle = cellStyle;

            //Draw the grid to PDF

            //var xxx = textElement.Draw(page,0,100);

            //Draw the second paragraph from the first paragraph’s end position.
            textElement.Draw(page, new RectangleF(0, 55, page.GetClientSize().Width, page.GetClientSize().Height), layoutFormat);
            table.Draw(page, new RectangleF(0, 500, page.GetClientSize().Width, page.GetClientSize().Height));
            MemoryStream stream = new MemoryStream();
            //Save and close the document.
            document.Save(stream);
            document.Close(true);
            File.WriteAllBytes("SampleSynMultipage.pdf", stream.ToArray());

            //Event handler for PageAdded event.
            void Pages_PageAdded(object sender, PageAddedEventArgs args)
            {
                PdfPage page = args.Page;
            }
        }

        public static void Multipage2()
        {
            //Create a new PDF document.
            PdfDocument document = new PdfDocument(PdfConformanceLevel.Pdf_A3A);
            //Add the event.
            document.Pages.PageAdded += new PageAddedEventHandler(Pages_PageAdded);
            //Create a new page and add it as the last page of the document.
            PdfPage page = document.Pages.Add();
            PdfGraphics graphics = page.Graphics;
            document.DocumentInformation.CreationDate = DateTime.Now;
            document.DocumentInformation.Creator = "มานะ2018";

            //Read the long text from the text file.
            //StreamReader reader = new StreamReader(@"input.txt", Encoding.ASCII);
            //string text = reader.ReadToEnd();
            //reader.Close();
            Stream fileStream = new FileStream("Input.xml", FileMode.Open, FileAccess.Read);
            PdfAttachment attachment = new PdfAttachment("Input.xml", fileStream);
            attachment.Relationship = PdfAttachmentRelationship.Alternative;
            attachment.ModificationDate = DateTime.Now;
            attachment.CreationDate = DateTime.Now;
            document.Attachments.Add(attachment);
            FileStream fontStream = new FileStream("Kanit-Light.ttf", FileMode.Open, FileAccess.Read);
            PdfFont font = new PdfTrueTypeFont(fontStream, true, PdfFontStyle.Regular, 14);
            PdfFont font10 = new PdfTrueTypeFont(fontStream, 10, PdfFontStyle.Regular);

            var text = "Hi! เอกสาร PDF มีการใช้อย่างแพร่หลายเป็นเวลาหลายปีและนับสิบ ๆ แถมฟรี ผู้อ่านPDF " +
                "เชิงพาณิชย์บรรณาธิการและห้องสมุดพร้อมใช้งาน อย่างไรก็ตามแม้จะมีความนิยมนี้ก็ยังคงยากที่จะหาคำแนะนำกระชับรูปแบบ PDF " +
                "พื้นเมืองการทำความเข้าใจการทำงานภายในของ PDF ทำให้สามารถสร้างได้แบบไดนามิกเอกสาร PDF " +
                "ตัวอย่างเช่นเว็บเซิร์ฟเวอร์สามารถดึงข้อมูลจากฐานข้อมูลใช้เพื่อกำหนดใบกำกับสินค้าและให้บริการกับลูกค้าได้ทันที Hello World!!! A  สวัสดีชาวโลก  ยินดีที่ได้รู้จัก B";
            var text2 = @"Why do we use it? It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout.The point of using Lorem Ipsum is that it has a more - or - less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English. Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy.Various versions have evolved over the years, sometimes by accident, sometimes on purpose(injected humour and the like).";
            var resulttext = text + text2 + "012345678901263456789,๑๒๓๔๕๖๗๘๙๐";

            var lortext = @"What is Lorem Ipsum?
Lorem Ipsum is simply dummy text of the printing and typesetting industry.Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.

Why do we use it ?
It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more - or - less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English. Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy.Various versions have evolved over the years, sometimes by accident, sometimes on purpose(injected humour and the like).
    


    Where does it come from ?
    Contrary to popular belief, Lorem Ipsum is not simply random text.It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old.Richard McClintock, a Latin professor at Hampden - Sydney College in Virginia, looked up one of the more obscure Latin words, consectetur, from a Lorem Ipsum passage, and going through the cites of the word in classical literature, discovered the undoubtable source.Lorem Ipsum comes from sections 1.10.32 and 1.10.33 of de Finibus Bonorum et Malorum(The Extremes of Good and Evil) by Cicero, written in 45 BC.This book is a treatise on the theory of ethics, very popular during the Renaissance.The first line of Lorem Ipsum, Lorem ipsum dolor sit amet.., comes from a line in section 1.10.32.";
            //Create a text element with the text and font.

            graphics.DrawString("บริษัท มานะ 2018 จำกัด", font, null, new PdfSolidBrush(new PdfColor(0, 0, 0)), 10, 60, null);
            graphics.DrawString("เลขที่ XS1425154843484", font, null, new PdfSolidBrush(new PdfColor(0, 0, 0)), 350, 60, null);
            graphics.DrawString("35/4 ซอยพระรามเก้า 57/1 (วิเศษสุข2) ", font, null, new PdfSolidBrush(new PdfColor(0, 0, 0)), 10, 80, null);
            graphics.DrawString("อัตราภาษีมูลค่าเพิ่ม 7.00%", font, null, new PdfSolidBrush(new PdfColor(0, 0, 0)), 350, 80, null);
            graphics.DrawString("แขวงพัฒนาการ เขตสวนหลวง กรุงเทพมหานคร", font, null, new PdfSolidBrush(new PdfColor(0, 0, 0)), 10, 100, null);

            graphics.DrawString("เลขประจำตัวผู้เสียภาษีอากร 0135560022933", font, null, new PdfSolidBrush(new PdfColor(0, 0, 0)), 10, 120, null);
            graphics.DrawString("วันที่ 17/06/2565", font, null, new PdfSolidBrush(new PdfColor(0, 0, 0)), 350, 120, null);

            graphics.DrawString("เลขประจำตัวผู้เสียภาษีอากร 1234567890123", font, null, new PdfSolidBrush(new PdfColor(0, 0, 0)), 10, 180, null);
            graphics.DrawString("ชื่อผู้ซื้อสินค้า : นายทนงทวย คงควรรอ", font, null, new PdfSolidBrush(new PdfColor(0, 0, 0)), 10, 200, null);
            graphics.DrawString("ที่อยู่ 12/34 ม.1 ต.ศิลา อ.เมืองขอนแก่น จ.ขอนแก่น 40000 เบอร์โทรศัพย์ 0966696699", font, null, new PdfSolidBrush(new PdfColor(0, 0, 0)), 10, 220, null);


            //สินค้า
            graphics.DrawString("NO.", font, null, new PdfSolidBrush(new PdfColor(0, 0, 0)), 10, 250, null);
            graphics.DrawString("จำนวน", font, null, new PdfSolidBrush(new PdfColor(0, 0, 0)), 40, 250, null);
            graphics.DrawString("รายการสินค้า", font, null, new PdfSolidBrush(new PdfColor(0, 0, 0)), 120, 250, null);
            graphics.DrawString("ราคาต่อหน่วย", font, null, new PdfSolidBrush(new PdfColor(0, 0, 0)), 300, 250, null);
            graphics.DrawString("ราคาภาษีมูลค่าเพิ่ม", font, null, new PdfSolidBrush(new PdfColor(0, 0, 0)), 400, 250, null);


            graphics.DrawString("1", font, null, new PdfSolidBrush(new PdfColor(0, 0, 0)), 10, 270, null);
            graphics.DrawString("1", font, null, new PdfSolidBrush(new PdfColor(0, 0, 0)), 70, 270, null);
            graphics.DrawString("กระเพาะหมูสับ", font, null, new PdfSolidBrush(new PdfColor(0, 0, 0)), 120, 270, null);
            graphics.DrawString("60.00", font, null, new PdfSolidBrush(new PdfColor(0, 0, 0)), 340, 270, null);
            graphics.DrawString("60.00", font, null, new PdfSolidBrush(new PdfColor(0, 0, 0)), 450, 270, null);

            graphics.DrawString("2", font, null, new PdfSolidBrush(new PdfColor(0, 0, 0)), 10, 290, null);
            graphics.DrawString("3", font, null, new PdfSolidBrush(new PdfColor(0, 0, 0)), 70, 290, null);
            graphics.DrawString("ไข่ดาว", font, null, new PdfSolidBrush(new PdfColor(0, 0, 0)), 120, 290, null);
            graphics.DrawString("15.00", font, null, new PdfSolidBrush(new PdfColor(0, 0, 0)), 340, 290, null);
            graphics.DrawString("45.00", font, null, new PdfSolidBrush(new PdfColor(0, 0, 0)), 450, 290, null);

            //Discount
            graphics.DrawString("หักส่วนลด", font, null, new PdfSolidBrush(new PdfColor(0, 0, 0)), 120, 310, null);
            graphics.DrawString("ส่วนลดค่าจัดส่ง", font, null, new PdfSolidBrush(new PdfColor(0, 0, 0)), 140, 330, null);
            graphics.DrawString("15.00", font, null, new PdfSolidBrush(new PdfColor(0, 0, 0)), 400, 330, null);

            //total
            //page.GetClientSize().Width
            graphics.DrawString("ส่วนลดที่ได้ทั้งหมด", font, null, new PdfSolidBrush(new PdfColor(0, 0, 0)), 120, 350, null);
            graphics.DrawString("15.00", font, null, new PdfSolidBrush(new PdfColor(0, 0, 0)), 400, 350, null);
            graphics.DrawString("สินค้าไม่เสียภาษีมูลค่าเพิ่ม", font, null, new PdfSolidBrush(new PdfColor(0, 0, 0)), 120, 370, null);
            graphics.DrawString("0.00", font, null, new PdfSolidBrush(new PdfColor(0, 0, 0)), 400, 370, null);
            graphics.DrawString("มูลค่าสินค้าก่อนภาษีมูลค่าเพิ่ม", font, null, new PdfSolidBrush(new PdfColor(0, 0, 0)), 120, 390, null);
            graphics.DrawString("97.65", font, null, new PdfSolidBrush(new PdfColor(0, 0, 0)), 400, 390, null);
            graphics.DrawString("ภาษีมูลค่าเพิ่ม", font, null, new PdfSolidBrush(new PdfColor(0, 0, 0)), 120, 410, null);
            graphics.DrawString("7.35", font, null, new PdfSolidBrush(new PdfColor(0, 0, 0)), 400, 410, null);
            graphics.DrawString("มูลค่าสินค้ารวมภาษีมูลค่าเพิ่ม", font, null, new PdfSolidBrush(new PdfColor(0, 0, 0)), 120, 430, null);
            graphics.DrawString("105.00", font, null, new PdfSolidBrush(new PdfColor(0, 0, 0)), 400, 430, null);
            graphics.DrawString("ยอดเงินชำระ", font, null, new PdfSolidBrush(new PdfColor(0, 0, 0)), 120, 450, null);
            graphics.DrawString("105.00", font, null, new PdfSolidBrush(new PdfColor(0, 0, 0)), 400, 450, null);

            //graphics.DrawString(resulttext, font, null, new PdfSolidBrush(new PdfColor(0, 0, 0)), 10, 470, null);


            PdfStringFormat format = new PdfStringFormat();
            format.ComplexScript = true;
            PdfTextElement textElement = new PdfTextElement(resulttext, font, null, null, format);
            PdfTextElement textElement2 = new PdfTextElement(lortext, font, null, null, format);
            PdfLayoutFormat layoutFormat = new PdfLayoutFormat();
            layoutFormat.Layout = PdfLayoutType.Paginate;
            //layoutFormat.Break = PdfLayoutBreakType.FitPage;
            format.EnableBaseline = true;
            format.EnableNewLineIndent = true;
            format.LineLimit = true;
            format.ParagraphIndent = 1;
            //format.WordSpacing = -1;
            format.MeasureTrailingSpaces = true;
            //Img
            FileStream imageStream = new FileStream("icon.png", FileMode.Open, FileAccess.Read);
            PdfBitmap image = new PdfBitmap(imageStream);
            graphics.DrawImage(image, new PointF(200, 0), new SizeF(50, 50));
            //Draw the first paragraph.
            //PdfLayoutResult result = textElement.Draw(page, new RectangleF(0, 0, page.GetClientSize().Width, page.GetClientSize().Height), layoutFormat);

            ////Signature
            //FileStream certificateStream = new FileStream("certificatedemo.pfx", FileMode.Open, FileAccess.Read);

            //PdfCertificate pdfCert = new PdfCertificate(certificateStream, "P@ssw0rd1234");
            //PdfSignature signature = new PdfSignature(document, page, pdfCert, "Signature");

            ////Sets an image for signature field 

            FileStream signatureimageStream = new FileStream("icon.png", FileMode.Open, FileAccess.Read);
            PdfBitmap signatureImage = new PdfBitmap(signatureimageStream);

            //Timestam
            //signature.TimeStampServer = new TimeStampServer(new Uri("http://syncfusion.digistamp.com"));
            //signature.Bounds = new RectangleF(new PointF(0, 0), signatureImage.PhysicalDimension);
            //signature.ContactInfo = "johndoe@owned.us";

            //signature.LocationInfo = "Honolulu, Hawaii";

            //signature.Reason = "I am author of this document.";

            ////Draws the signature image
            ////signature.TimeStampServer = new TimeStampServer(new Uri("http://syncfusion.digistamp.com"), "user", "123456");
            //graphics.DrawImage(signatureImage, 0, 0);
            //==============================

            //table
            //Create a new PDF light table
            PdfLightTable table = new PdfLightTable();

            //Create IEnumerable custom object
            List<Customer> customerDetails = new List<Customer>();

            for (int i = 0; i < 6; i++)
            {
                Customer customer = new Customer();
                customer.ID = i;
                customer.Name = "ABC";
                customer.Age = 26;
                customerDetails.Add(customer);
            }

            //Enable the table header
            table.Style.ShowHeader = true;

            //Set the custom object as table data source
            table.DataSource = customerDetails;

            table.Style.CellPadding = 2;

            //Create a new PdfCellStyle instance
            PdfCellStyle headerStyle = new PdfCellStyle();

            //Assign font
            //headerStyle.Font = new PdfStandardFont(PdfFontFamily.Helvetica, 10, PdfFontStyle.Bold);
            headerStyle.Font = font;
            //Set alignment
            headerStyle.StringFormat = new PdfStringFormat(PdfTextAlignment.Center);

            //Set header style.
            table.Style.HeaderStyle = headerStyle;

            //Create new PdfCellStyle instance
            PdfCellStyle cellStyle = new PdfCellStyle();

            //Set font 
            //cellStyle.Font = new PdfStandardFont(PdfFontFamily.Helvetica, 10, PdfFontStyle.Regular);
            cellStyle.Font = font;
            //Set alignment
            cellStyle.StringFormat = new PdfStringFormat(PdfTextAlignment.Center);

            //Set default cell style
            table.Style.DefaultStyle = cellStyle;

            //Draw the grid to PDF

            //var xxx = textElement.Draw(page,0,100);
            //Footer
            RectangleF bounds = new RectangleF(0, 0, document.Pages[0].GetClientSize().Width, 50);
            PdfPageTemplateElement footer = new PdfPageTemplateElement(bounds);
            PdfBrush brush = new PdfSolidBrush(new PdfColor(Syncfusion.Drawing.Color.Black));
            PdfPageNumberField pageNumber = new PdfPageNumberField(font, brush);
            PdfPageCountField count = new PdfPageCountField(font, brush);
            PdfCompositeField compositeField = new PdfCompositeField(font10, brush, "Page {0} of {1}", pageNumber, count);
            compositeField.Bounds = footer.Bounds;
            //graphics.DrawImage(signatureImage, 0, 0);
            footer.Background = true;
            footer.Graphics.DrawString("Digitally Signed By บริษัท มานะ 2018 จำกัด", font10, PdfBrushes.Black, new PointF(0, 0));
            footer.Graphics.DrawString("เอกสารฉบับนี้ได้จัดทำและส่งข้อมูลให้แก่กรมสรรพากรด้วยวิธีการอิเล็กทรอนิกส์", font10, PdfBrushes.Black, new PointF(0, 20));
            compositeField.Draw(footer.Graphics, new PointF(400, 20));
            document.Template.Bottom = footer;
            //Draw the second paragraph from the first paragraph’s end position.
            PdfLayoutResult result = textElement.Draw(page, new RectangleF(10, 480, page.GetClientSize().Width, page.GetClientSize().Height), layoutFormat);
            //PdfLine line = new PdfLine(new PointF(0, 0), new PointF(page.GetClientSize().Width, 0))
            //{
            //    Pen = PdfPens.DarkGray
            //};
            //result = line.Draw(page, new PointF(0, result.Bounds.Bottom + 5));
            textElement2.Draw(result.Page, new RectangleF(0, result.Bounds.Bottom + 20, page.GetClientSize().Width, page.GetClientSize().Height));

            //result = textElement2.Draw(page, new PointF());
            //textElement.Draw(page, new RectangleF(10, 480, page.GetClientSize().Width, page.GetClientSize().Height), layoutFormat);

            //table.Draw(page, new RectangleF(0, 500, page.GetClientSize().Width, page.GetClientSize().Height));
            MemoryStream stream = new MemoryStream();
            //Save and close the document.
            document.Save(stream);
            document.Close(true);
            File.WriteAllBytes("SampleBill.pdf", stream.ToArray());

            //Event handler for PageAdded event.
            void Pages_PageAdded(object sender, PageAddedEventArgs args)
            {
                PdfPage page = args.Page;
            }
        }
    }
    public class Customer
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }

}

