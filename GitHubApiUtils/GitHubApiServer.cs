using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitHubApiUtils
{
    /// <summary>
    /// IGitHubApi implementation for server side execution.
    /// Uses regular HTTP Client.
    /// </summary>
    public class GitHubApiServer : IGitHubApi
    {
        public GitHubRepoRelease GetLatestRepoRelease(string owner, string repo)
        {
            throw new NotImplementedException();
        }

        public List<GitHubRepoRelease> GetRepoReleaseList(string owner, string repo)
        {
            throw new NotImplementedException();
        }
    }
}
