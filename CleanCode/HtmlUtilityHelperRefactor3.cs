using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCode
{
    internal class HtmlUtilityHelperRefactor3
    {
        public static string RenderPageWithSetupsAndTeardowns(PageData pageData, bool isSuite)
        {
            return SetupTeardownIncluder.Render(pageData, isSuite);
        }
    }

    class SetupTeardownIncluder
    {
        private bool _isSuite;
        private PageData _pageData;
        private StringBuilder _newPageContent;
        private WikiPage _testPage;
        private PageCrawler _pageCrawler;
        public SetupTeardownIncluder(PageData pageData)
        {
            _pageData = pageData;
            _testPage = pageData.GetWikiPage();
            _pageCrawler = _testPage.GetPageCrawler();
            _newPageContent = new StringBuilder();
        }

        public static string Render(PageData pageData)
        {
            return Render(pageData, isSuite: false);
        }
        public static string Render(PageData pageData, bool isSuite)
        {
            SetupTeardownIncluder setupTeardownIncluder = new SetupTeardownIncluder(pageData);
            return setupTeardownIncluder.Render(isSuite);
        }

        private string Render(bool isSuite)
        {
            _isSuite = isSuite;
            if (IsTestPage())
            {
                IncludeSetupAndTearDownPages();
            }
            return _pageData.GetHtml();
        }

        private bool IsTestPage()
        {
            return _pageData.HasAttribute("Test");
        }

        private void IncludeSetupAndTearDownPages()
        {
            IncludeSetupPages();
            IncludePageContent();
            IncludeTeardownPages();
            UpdatePageContent();
        }

        private void IncludeSetupPages()
        {
            if (_isSuite)
            {
                IncludeSuiteSetupPage();
            }
            IncludeSetupPage();
        }

        private void IncludeSuiteSetupPage()
        {
            Include(SuiteResponder.SuiteSetupName, "-setup");
        }

        private void IncludeSetupPage()
        {
            Include("SetUp", "-setup");
        }

        private void IncludePageContent()
        {
            _newPageContent.Append(_pageData.GetContent());
        }

        private void IncludeTeardownPages()
        {
            IncludeTeardownPage();
            if (_isSuite)
            {
                IncludeSuiteTearDownPage();
            }
        }

        private void IncludeSuiteTearDownPage()
        {
            Include("TearDown", "-teardown");
        }

        private void IncludeTeardownPage()
        {
            Include(SuiteResponder.SuiteTearDownName, "-teardown");
        }

        private void UpdatePageContent()
        {
            _pageData.SetContent(_newPageContent.ToString());
        }

        private void Include(string pageName, string arg)
        {
            WikiPage inheritedPage = FindInheritedPage(pageName);
            if (inheritedPage != null)
            {
                string pagePathName = GetPathNameForPage(inheritedPage);
                BuildIncludeDirective(arg, pagePathName);
            }
        }

        private void BuildIncludeDirective(string arg, string pagePathName)
        {
            _newPageContent.AppendLine()
                           .Append("!include ")
                           .Append(arg)
                           .Append('.')
                           .Append(pagePathName)
                           .AppendLine();
        }

        private string GetPathNameForPage(WikiPage page)
        {
            WikiPagePath pagePath = _pageCrawler.GetFullPath(page);
            return PathParser.Render(pagePath);
        }

        private WikiPage FindInheritedPage(string pageName)
        {
            return PageCrawler.GetInheritedPage(pageName, _testPage);
        }
    }
}
