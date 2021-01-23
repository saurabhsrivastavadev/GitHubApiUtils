using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitHubApiUtils
{
    internal class GitHubRepoReleaseJson
    {
        public int id { get; set; }

        public string tag_name { get; set; }

        public string name { get; set; }

        public List<GitHubRepoReleaseAssetJson> assets { get; set; }

        public DateTime published_at { get; set; }

        public string body { get; set; }

        public GitHubRepoRelease ToGitHubRepoRelease()
        {
            return new GitHubRepoRelease(
                            Id: id,
                            TagName: tag_name,
                            Name: name,
                            Assets: assets.ConvertAll(a => a.ToGitHubRepoReleaseAsset()),
                            PublishedAt: published_at,
                            Body: body);
        }
    }

    internal class GitHubRepoReleaseAssetJson
    {
        public int id { get; set; }

        public DateTime created_at { get; set; }

        public string browser_download_url { get; set; }

        public GitHubRepoReleaseAsset ToGitHubRepoReleaseAsset()
        {
            return new GitHubRepoReleaseAsset(
                            Id: id,
                            CreatedAt: created_at,
                            BrowserDownloadUrl: browser_download_url);
        }
    }
}