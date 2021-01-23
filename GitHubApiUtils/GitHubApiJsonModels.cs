using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitHubApiUtils
{
    internal class GitHubRepoReleaseJson
    {
        public string tag_name { get; set; }

        public string name { get; set; }

        public List<GitHubRepoReleaseAssetJson> assets { get; set; }

        public DateTime published_at { get; set; }

        public string body { get; set; }

        public GitHubRepoRelease ToGitHubRepoRelease()
        {
            return new GitHubRepoRelease(
                tag_name, name,
                assets.ConvertAll(a => a.ToGitHubRepoReleaseAsset()),
                published_at, body);
        }
    }

    internal class GitHubRepoReleaseAssetJson
    {
        public DateTime created_at { get; set; }

        public string browser_download_url { get; set; }

        public GitHubRepoReleaseAsset ToGitHubRepoReleaseAsset()
        {
            return new GitHubRepoReleaseAsset(created_at, browser_download_url);
        }
    }
}