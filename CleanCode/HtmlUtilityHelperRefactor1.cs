using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCode
{
    internal class HtmlUtilityHelperRefactor1
    {
        public static string RenderPageWithSetupsAndTeardowns(PageData pageData, bool isSuite)
        {
            bool isTestPage = pageData.HasAttribute("Test");
            
            if (isTestPage)
            {
                WikiPage testPage = pageData.GetWikiPage();
                StringBuilder newPageContent = new StringBuilder();
                IncludeSetupPages(testPage, newPageContent, isSuite);
                newPageContent.Append(pageData.GetContent());
                IncludeTearDownPages(isSuite, testPage, newPageContent);
                pageData.SetContent(newPageContent.ToString());
            }

            return pageData.GetHtml();
        }

        private static void IncludeTearDownPages(bool isSuite, WikiPage testPage, StringBuilder newPageContent)
        {
            WikiPage tearDown = PageCrawler.GetInheritedPage("TearDown", testPage);
            if (tearDown != null)
            {
                WikiPagePath tearDownPath = testPage.GetPageCrawler().GetFullPath(tearDown);
                string tearDownPathName = PathParser.Render(tearDownPath);
                newPageContent.AppendLine()
                             .Append("!include -teardown .")
                             .Append(tearDownPathName)
                             .AppendLine();
            }
            if (isSuite)
            {
                WikiPage suiteTearDown = PageCrawler.GetInheritedPage(SuiteResponder.SuiteTearDownName, testPage);
                if (suiteTearDown != null)
                {
                    WikiPagePath pagePath = suiteTearDown.GetPageCrawler().GetFullPath(suiteTearDown);
                    string pagePathName = PathParser.Render(pagePath);
                    newPageContent.Append("!include -teardown .")
                                 .Append(pagePathName)
                                 .AppendLine();
                }

            }
        }

        private static void IncludeSetupPages(WikiPage wikiPage, StringBuilder newPageContent, bool isSuite)
        {
            if (isSuite)
            {
                WikiPage suiteSetup = PageCrawler.GetInheritedPage(SuiteResponder.SuiteSetupName, wikiPage);
                if (suiteSetup != null)
                {
                    WikiPagePath pagePath = suiteSetup.GetPageCrawler().GetFullPath(suiteSetup);
                    string pagePathName = PathParser.Render(pagePath);
                    newPageContent.Append("!include -setup .")
                                 .Append(pagePathName)
                                 .AppendLine();
                }
            }
            WikiPage setup = PageCrawler.GetInheritedPage("Setup", wikiPage);
            if (setup != null)
            {
                WikiPagePath setupPath = wikiPage.GetPageCrawler().GetFullPath(setup);
                string setupPathName = PathParser.Render(setupPath);
                newPageContent.Append("!include -setup .")
                             .Append(setupPathName)
                             .AppendLine();
            }
        }
    }
}
