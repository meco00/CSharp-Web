using MyWebServer.Http;
using System;
using System.IO;
using System.Linq;

namespace MyWebServer.Results
{
    public class ViewResult : ActionResult
    {
        private const char PathSeparator = '/';

        public ViewResult(
            HttpResponse response,
            string viewName,
            string controllerName,
            object model) 
            : base(response)
        {
            
            this.GetHtml(viewName,controllerName,model);
        }

        private void GetHtml(string viewName,string controllerName,object model)
        {
            var viewPath = string.Empty;


            if (!viewName.Contains(PathSeparator))
            {
                viewName = controllerName + PathSeparator + viewName;
            }


            viewPath = Path.GetFullPath("./Views/" + viewName.TrimStart(PathSeparator)+".cshtml");

            if (!File.Exists(viewPath))
            {
                this.PrepareMissingView(viewPath);
                return ;
            }

            var viewContent = File.ReadAllText(viewPath);

            if (model != null)
            {
                viewContent = this.PopulateModel(viewContent, model);
            }

            this.SetContent(viewContent, HttpContentType.Html);



        }

        private void PrepareMissingView(string viewPath)
        {
            this.StatusCode = HttpStatusCode.NotFound;

            var errorMesage = $"View '{viewPath}' was not found.";

            this.SetContent(errorMesage,HttpContentType.PlainText);
        }

        private string PopulateModel(string viewContent,object model)
        {
            var data = model
                .GetType()
                .GetProperties()
                .Select(pr => new
                {
                    Name = pr.Name,
                    Value = pr.GetValue(model)
                });

            foreach (var entry in data)
            {
                const string openingBrackets = "{{";
                const string closingBrackets = "}}";
                viewContent = viewContent.Replace($"{openingBrackets}{entry.Name}{closingBrackets}", entry.Value.ToString());
            }

            return viewContent;

        }
    }
}
