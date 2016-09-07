using NUnit.Framework;
using TestTask1.forms;
using TestTask1.framework;

namespace TestTask1.tests
{
    class Tests:BaseTest
    {
        private const string FileName = "newfile1";
        private const string RepositoryName = "1";

        [Test]
        public void CreateFileTest()
        {
            new StartForm().OpenSignInPage();
            new SignInForm().SingIn(Configuration.GetUserLogin(), Configuration.GetPassword());
            new LoggedInStartForm().OpenRepository(RepositoryName);

            RepositoryStartForm reposForm = new RepositoryStartForm();
            reposForm.OpenCreateFilePage();

            CreateFileForm createForm = new CreateFileForm();
            createForm.CreateFile(FileName);
            reposForm.VerifyFileIsCreated(FileName);
            reposForm.OpenCreateFilePage();
            createForm.CreateFile(FileName);
            createForm.VerifyExceptionIsPresent();
        }

        private const string BranchName = "1";

        [TestCase("newfile2")]
        public void MergeBranchTest(string fileName)
        {
            new StartForm().OpenSignInPage();
            new SignInForm().SingIn(Configuration.GetUserLogin(), Configuration.GetPassword());
            new LoggedInStartForm().OpenRepository(RepositoryName);

            RepositoryStartForm reposForm = new RepositoryStartForm();
            reposForm.CreateBranch(BranchName);
            reposForm.OpenCreateFilePage();

            CreateFileForm createForm = new CreateFileForm();
            createForm.CreateFile(fileName);
            reposForm.OpenPullRequestForm();
            new PullRequestForm().CreatePullRequest();
            MergePullRequestForm mergeForm = new MergePullRequestForm();
            mergeForm.MergePullRequest();
            mergeForm.VerifyBranchIsMerged();
        }

       [TestCase("newIssue1")]
        public void CreateIssueTest(string issueName)
        {
            new StartForm().OpenSignInPage();
            new SignInForm().SingIn(Configuration.GetUserLogin(), Configuration.GetPassword());
            new LoggedInStartForm().OpenRepository(RepositoryName);
            new RepositoryStartForm().OpenIssuesPage();
            IssuesForm issuesForm = new IssuesForm();
            issuesForm.CreateNewIssue(issueName);
            issuesForm.VerifyIssueIsCreated(issueName);
        }

        [TestCase("newIssue2")]
        public void CloseIssueTest(string issueName)
        {
            new StartForm().OpenSignInPage();
            new SignInForm().SingIn(Configuration.GetUserLogin(), Configuration.GetPassword());
            new LoggedInStartForm().OpenRepository(RepositoryName);

            RepositoryStartForm reposForm = new RepositoryStartForm();
            reposForm.OpenIssuesPage();
            IssuesForm issuesForm = new IssuesForm();
            issuesForm.CreateNewIssue(issueName);
            issuesForm.CloseIssue();
            reposForm.OpenPulsePage();
            new PulseForm().VerifyAllIssuesIsClosed();
        }

        [TestCase("newIssue3","bug")]
        public void ReopenIssueTest(string issueName, string issueLabel)
        {
            new StartForm().OpenSignInPage();
            new SignInForm().SingIn(Configuration.GetUserLogin(), Configuration.GetPassword());
            new LoggedInStartForm().OpenRepository(RepositoryName);

            RepositoryStartForm reposForm = new RepositoryStartForm();
            reposForm.OpenIssuesPage();
            IssuesForm issuesForm = new IssuesForm();
            issuesForm.CreateNewIssue(issueName);
            issuesForm.CloseIssue();
            reposForm.OpenPulsePage();
            new PulseForm().ReopenIssue();
            issuesForm.ReopenIssue(issueLabel);
            reposForm.OpenIssuesPage();
            issuesForm.VerifyIssueIsReopened(issueLabel);
            
        }
    }
}
