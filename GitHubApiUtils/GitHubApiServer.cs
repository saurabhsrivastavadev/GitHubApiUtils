using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace GitHubApiUtils
{
    /// <summary>
    /// IGitHubApi implementation for server side execution.
    /// Uses regular HTTP Client.
    /// </summary>
    public class GitHubApiServer : IGitHubApi
    {
        private readonly HttpClient _httpClient;

        public GitHubApiServer(HttpClient httpClient)
        {
            httpClient.BaseAddress = new Uri("https://api.github.com");

            // GitHub API versioning
            httpClient.DefaultRequestHeaders.Add(
                "Accept", "application/vnd.github.v3+json");

            // GitHub requires a user-agent
            httpClient.DefaultRequestHeaders.Add(
                "User-Agent", "GitHubApiUtils.GitHubApiServer");

            _httpClient = httpClient;
        }

        public async Task<GitHubRepoRelease> GetLatestRepoRelease(string owner, string repo)
        {
            var releaseList = await GetRepoReleaseList(owner, repo);

            if (releaseList.Count == 0)
            {
                return null;
            }

            var maxPublishedAt = releaseList.Max(r => r.PublishedAt);
            return releaseList.First(r => r.PublishedAt == maxPublishedAt);
        }

        public async Task<List<GitHubRepoRelease>> GetRepoReleaseList(string owner, string repo)
        {
            var response = await _httpClient.GetAsync($"repos/{owner}/{repo}/releases");

            response.EnsureSuccessStatusCode();

            using var responseStream = await response.Content.ReadAsStreamAsync();
            var releaseList = await JsonSerializer.DeserializeAsync
                                        <List<GitHubRepoReleaseJson>>(responseStream);

            return releaseList.ConvertAll<GitHubRepoRelease>(r => r.ToGitHubRepoRelease());
        }
    }
}
