using IBM07Feb2024_FormsAuthAspMVC5.Infra;
using iText.Html2pdf;
using iText.Html2pdf.Attach.Impl;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.StyledXmlParser.Node;




//using iText.Kernel.Pdf;
//using iText.Layout;
//using iText.Layout.Element;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;

namespace IBM07Feb2024_FormsAuthAspMVC5.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
      
        
        public ActionResult Index()
        {
            //PdfDocument pdfDocument = new PdfDocument(new PdfWriter(new FileStream("D:\\Classdemo\\a.pdf", FileMode.Create, FileAccess.Write)));
            //Document document = new Document(pdfDocument);

            //String line = "Hello! Welcome to iTextPdf";
            //document.Add(new Paragraph(line));
            //document.Close();
            //Console.WriteLine("Awesome PDF just got created.");




            //Console.WriteLine                ("Awesome PDF just got created.");


            return View();
        }

        public ActionResult error()
        {
            return View();
        }
        
        public ActionResult errorFormat()
        {
            return View();
        }



        public void manipulatePdf(string htmlSource, string pdfDest, string resourceLoc)
        {
            // Base URI is required to resolve the path to source files
            ConverterProperties converterProperties = new ConverterProperties().SetBaseUri(resourceLoc);

            using (var htmlStream =  System.IO.File.OpenRead(htmlSource))
            {
                if (System.IO.File.Exists(pdfDest))
                {
                    System.IO.File.Delete(pdfDest);
                }
                using (var pdfStream = System.IO.File.OpenWrite(pdfDest))
                {
                    IDictionary<string, int?> priorityMappings = new Dictionary<string, int?>();
                    priorityMappings.Add("p", 1);
                    priorityMappings.Add("h1", 2);
                    OutlineHandler customOutlineHandler = new CustomOutlineHandler().PutAllTagPriorityMappings(priorityMappings);
                    customOutlineHandler.SetDestinationNamePrefix("custom-prefix-");
                    converterProperties.SetOutlineHandler(customOutlineHandler);
                    HtmlConverter.ConvertToPdf(htmlStream, pdfStream, converterProperties);
                }
            }

            // Create custom outline handler

        }


        public class CustomOutlineHandler : OutlineHandler
        {

            protected override string GenerateUniqueDestinationName(IElementNode element)
            {
                string destinationName = base.GenerateUniqueDestinationName(element);
                if ("p".Equals(element.Name()))
                {
                    destinationName = destinationName.Replace(GetDestinationNamePrefix(), "paragraph-prefix-");
                }
                return destinationName;
            }
        }

    }

    }
