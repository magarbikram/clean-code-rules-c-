using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCode
{
    internal class HtmlUtilityHelper
    {
        public static string RenderPageWithSetupsAndTeardowns(PageData pageData, bool includeSuiteSetup)
        {
            WikiPage wikiPage = pageData.GetWikiPage();
            StringBuilder stringBuilder = new StringBuilder();
            if (pageData.HasAttribute("Test"))
            {
                if (includeSuiteSetup)
                {
                    WikiPage suiteSetup = PageCrawler.GetInheritedPage(SuiteResponder.SuiteSetupName, wikiPage);
                    if (suiteSetup != null)
                    {
                        WikiPagePath pagePath = suiteSetup.GetPageCrawler().GetFullPath(suiteSetup);
                        string pagePathName = PathParser.Render(pagePath);
                        stringBuilder.Append("!include -setup .")
                                     .Append(pagePathName)
                                     .AppendLine();
                    }
                }
                WikiPage setup = PageCrawler.GetInheritedPage("Setup", wikiPage);
                if (setup != null)
                {
                    WikiPagePath setupPath = wikiPage.GetPageCrawler().GetFullPath(setup);
                    string setupPathName = PathParser.Render(setupPath);
                    stringBuilder.Append("!include -setup .")
                                 .Append(setupPathName)
                                 .AppendLine();
                }
            }
            stringBuilder.Append(pageData.GetContent());
            if (pageData.HasAttribute("Test"))
            {
                WikiPage tearDown = PageCrawler.GetInheritedPage("TearDown", wikiPage);
                if (tearDown != null)
                {
                    WikiPagePath tearDownPath = wikiPage.GetPageCrawler().GetFullPath(tearDown);
                    string tearDownPathName = PathParser.Render(tearDownPath);
                    stringBuilder.AppendLine()
                                 .Append("!include -teardown .")
                                 .Append(tearDownPathName)
                                 .AppendLine();
                }
                if (includeSuiteSetup)
                {
                    WikiPage suiteTearDown = PageCrawler.GetInheritedPage(SuiteResponder.SuiteTearDownName, wikiPage);
                    if (suiteTearDown != null)
                    {
                        WikiPagePath pagePath = suiteTearDown.GetPageCrawler().GetFullPath(suiteTearDown);
                        string pagePathName = PathParser.Render(pagePath);
                        stringBuilder.Append("!include -teardown .")
                                     .Append(pagePathName)
                                     .AppendLine();
                    }

                }
            }
            pageData.SetContent(stringBuilder.ToString());
            return pageData.GetHtml();
        }
    }
}
