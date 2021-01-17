using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace GitHubApiUtils.Test
{
    [TestClass]
    public class TestGitHubApiServer
    {
        [TestMethod]
        public void TestGetRepoReleaseList()
        {
            var api = new GitHubApiServer();
            var releases = api.GetRepoReleaseList("sobu86", "GitHubApiUtils");
            Assert.IsNotNull(releases);
        }

        [TestMethod]
        public void TestGetLastestRepoRelease()
        {
            var api = new GitHubApiServer();
            var latest = api.GetLatestRepoRelease("sobu86", "GitHubApiUtils");
            Assert.IsNotNull(latest);
        }

        [TestMethod]
        public void TestInvalidRepoNameReleaseList()
        {
            var api = new GitHubApiServer();

            bool exception = false;

            try
            {
                api.GetRepoReleaseList("sobu86", "invalid_repo");
            }
            catch (ArgumentException)
            {
                exception = true;
            }

            Assert.IsTrue(exception);
        }

        [TestMethod]
        public void TestInvalidRepoNameLatestRelease()
        {
            var api = new GitHubApiServer();

            bool exception = false;

            try
            {
                api.GetLatestRepoRelease("sobu86", "invalid_repo");
            }
            catch (ArgumentException)
            {
                exception = true;
            }

            Assert.IsTrue(exception);
        }
    }
}
