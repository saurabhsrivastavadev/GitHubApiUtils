using System;
using System.Collections.Generic;

namespace GitHubApiUtils
{
    /// <summary>
    /// Interface to interact with GitHub API.
    /// API defined @ https://docs.github.com/en/rest/reference
    /// </summary>
    public interface IGitHubApi
    {
        /// <summary>
        /// Get the list of all releases for the specified repo
        /// identified by owner id and repo id
        /// </summary>
        /// <param name="owner"></param>
        /// <param name="repo"></param>
        /// <returns>
        /// List of releases, empty list if there are no releases.
        /// ArgumentException for invalid owner/repo combination.
        /// </returns>
        List<GitHubRepoRelease> GetRepoReleaseList(string owner, string repo);

        /// <summary>
        /// Get the latest release for the specified repo
        /// identified by owner id and repo id
        /// </summary>
        /// <param name="owner"></param>
        /// <param name="repo"></param>
        /// <returns>
        /// Latest release, null if there are no releases.
        /// ArgumentException for invalid owner/repo combination.
        /// </returns>
        GitHubRepoRelease GetLatestRepoRelease(string owner, string repo);
    }

    /// <summary>
    /// Record containing relevant details of a Repo Release.
    /// Assets will be an empty list if there are no assets.
    /// </summary>
    public record GitHubRepoRelease(
        string TagName, string Name, List<GitHubRepoReleaseAsset> Assets,
        DateTime PublishedAt, string Body);

    /// <summary>
    /// Record containing relevant details of a Release Asset.
    /// </summary>
    public record GitHubRepoReleaseAsset(
        DateTime CreatedAt, string BrowserDownloadUrl);
}

