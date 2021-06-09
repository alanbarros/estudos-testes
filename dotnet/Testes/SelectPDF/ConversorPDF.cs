using System;
using System.Drawing;
using System.IO;
using SelectPdf;

namespace SelectPDF
{
    internal class ConversorPDF
    {
        private HtmlToPdf converter {get; set;}
        private PdfDocument Doc;

        private bool useProxy;
        public bool UseProxy 
        { 
            get
            {
                return useProxy;
            } 
            
            set 
            {
                useProxy = value;
                var proxy = useProxy ? GetProxy : new Proxy();

                // set the proxy options
                converter.Options.ProxyOptions.HostName = proxy.Hostname;
                converter.Options.ProxyOptions.PortNumber = proxy.PortNumber;
                converter.Options.ProxyOptions.Username = proxy.UserName;
                converter.Options.ProxyOptions.Password = proxy.PassWord;
                converter.Options.ProxyOptions.Type = proxy.Type;
            }
        }
        public ConversorPDF()
        {
            Configure();
        }
        public void Add(string htmlString, string baseUrl, bool manualStartup = false)
        {
            //htmlString = string.Concat(htmlString, GetStringStartPDF());

            converter.Options.StartupMode = manualStartup ? HtmlToPdfStartupMode.Manual : HtmlToPdfStartupMode.Automatic;
            AddPdfDocument(converter.ConvertHtmlString(htmlString, baseUrl).Pages);
        }

        public static string GetStringStartPDF()
        {
            return "<script type=\"text/javascript\">function DetectaOTermino(){var numMpas=GMapController.mapsToLoad.length; for (i=0; i < numMpas; i++){var m=GMapController.mapsToLoad[i].get_map(); if (!m.carregou){//tem algum mapa que ainda nao carregou setTimeout(DetectaOTermino, 1000); return;}}if (typeof (selectpdf)==\"object\"){selectpdf.start(); return;}}function AdicionaVerificacaoDeTerimio(){if (typeof (google)==\"undefined\" || typeof (jQuery)==\"undefined\" || typeof (GMapController)==\"undefined\" || typeof (GMapController.mapsToLoad)==\"undefined\" || document.readyState !=\"complete\" ){setTimeout(AdicionaVerificacaoDeTerimio, 1000); return;}var numMpas=GMapController.mapsToLoad.length; for (i=0; i < numMpas; i++){var m=GMapController.mapsToLoad[i].get_map(); m.carregou=!m.tilesloading; google.maps.event.addListenerOnce(m, \"tilesloaded\", function (){this.carregou=true;});}DetectaOTermino();}AdicionaVerificacaoDeTerimio();</script>";
        }
        public void Add(string htmlString, bool manualStartup = false)
        {
            converter.Options.StartupMode = manualStartup ? HtmlToPdfStartupMode.Manual : HtmlToPdfStartupMode.Automatic;
            AddPdfDocument(converter.ConvertHtmlString(htmlString).Pages);
        }

        public void Add(FileInfo arquivo)
        {
            PdfDocument anexo;

            if (arquivo.Extension.Equals(".pdf"))
                anexo = new PdfDocument(arquivo.FullName);
            else
                anexo = CreatePdfWithImageFile(arquivo.FullName, arquivo.Name);

            AddPdfDocument(anexo.Pages);
        }

        private PdfDocument CreatePdfWithImageFile(string fullName, string name)
        {
            PdfDocument doc = new PdfDocument();
            PdfPage page = doc.AddPage();
            PdfFont font = doc.AddFont(PdfStandardFont.Helvetica);
            font.Size = 12;

            PdfRenderingResult result;
            
            PdfTextElement text = new PdfTextElement(0, 0, name, font);
            result = page.Add(text);
            PdfImageElement img = new PdfImageElement(0, result.PdfPageLastRectangle.Bottom + 50, fullName);
            result = page.Add(img);

            return doc;
        }

        private void AddPdfDocument(PdfPageCollection pages)
        {
            foreach(PdfPage page in pages)
            {
                Doc.AddPage(page);
                PageNumbering(Doc.Pages.Count -1);
            }
        }

        private void PageNumbering(int pageIndex)
        {
            FontFamily fontFamily = new FontFamily("Arial");
            Font font = new Font(
            fontFamily,
            8,
            FontStyle.Regular,
            GraphicsUnit.Pixel);

            Doc.Footer = Doc.AddTemplate(Doc.Pages[pageIndex].ClientRectangle.Width, 100);
            Doc.Footer.Foreground = false;
            PdfElement textFooter = new PdfTextElement(converter.Options.MarginLeft, 80, "Página: {page_number} de {total_pages}", Doc.AddFont(font));
            textFooter.ForeColor = System.Drawing.Color.Black;
            Doc.Footer.Add(textFooter);
        }

        public void Salvar(string nomeArquivo)
        {
            Doc.Save(nomeArquivo);
            Doc.Close();
        }

        private void Configure()
        {
            converter = new HtmlToPdf();

            Doc = new PdfDocument();

            converter.Options.PdfPageSize = PdfPageSize.A4;
            converter.Options.PdfPageOrientation = PdfPageOrientation.Portrait;
            converter.Options.WebPageWidth = 1024;
            converter.Options.WebPageHeight = 0;

            converter.Options.MarginLeft = 30;
            converter.Options.MarginRight = 30;
            converter.Options.MarginTop = 30;
            converter.Options.MarginBottom = 30;

            //set startup configuration
            converter.Options.JavaScriptEnabled = true;
            converter.Options.CssMediaType = HtmlToPdfCssMediaType.Print;
            
        }
        private Proxy GetProxy => 
            new Proxy("smapro-cl1", 9090, @"sma.local@alanbarros", "Winterwolf3647a", NetworkProxyType.Http);
    }

    class Proxy
    {
        public string Hostname { get; set; }
        public int PortNumber { get; set; }
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public SelectPdf.NetworkProxyType Type { get; set; }
        public Proxy(string hostName, int portNumber, string userName, string passWord, SelectPdf.NetworkProxyType type)
        {
            Hostname = hostName;
            PortNumber = portNumber;
            UserName = userName;
            PassWord = passWord;
            Type = type;
        }
        public Proxy(){}
    }
}