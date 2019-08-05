using System;
using System.IO;

namespace SelectPDF
{
    class Program
    {
        static void Main(string[] args)
        {
            //var urlBase = @"https://localhost:44398/Sigam3/";
            //var urlBase = @"https://sigam.ambiente.sp.gov.br/sigam3/";
            var basePath = @"C:\Users\alanbarros\Desktop\Desk\tasks\selectPDF\";

            var page = new ConversorPDF();
            page.UseProxy = true;

            var proxyTest = File.ReadAllText(basePath + "imagens.html");
            var htmlResumoCAR = File.ReadAllText(basePath + "resumo1507.html");
            var htmlResumoSARE = File.ReadAllText(basePath + "resumoSare_2_2407.html");
            var htmlTermo = File.ReadAllText(basePath + "loremIpsum.html");
            // var imagem = new FileInfo(@"C:\Users\alanbarros\Pictures\logoNASCENTES.jpg");
            // var pdf = new FileInfo(@"C:\Users\alanbarros\Downloads\curriculo.pdf");
            //var testeMapa = File.ReadAllText(basePath + "testeProxy.html");

            //page.Add(htmlResumoCAR, urlBase, true);
            //page.Add(htmlResumoCAR, urlBase);
            page.Add(htmlTermo);

            //page.Add(imgTest);

            page.Salvar(@"termo22222.pdf");
        }
    }
}
