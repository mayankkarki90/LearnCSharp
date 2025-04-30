using System.Net;

namespace LearnCSharp
{
    /// <summary>
    /// Github api request handlers
    /// </summary>
    public class GitApiHandler
    {
        private readonly string _patToken;

        /// <summary>
        /// The git required headers
        /// All API requests must include a valid User-Agent header. Requests with no User-Agent header will be rejected. 
        /// We request that you use your GitHub username, or the name of your application, 
        /// for the User-Agent header value. This allows us to contact you if there are problems.
        /// </summary>
        private Dictionary<string, string> _githubApiRequiredHeaders = new Dictionary<string, string> {
            { "User-Agent", "request"}
        };

        public GitApiHandler(string patToken)
        {
            _patToken = patToken;
        }

        /// <summary>
        /// Creates the pull request.
        /// </summary>
        /// <param name="repositoryUrl">The repository URL.</param>
        /// <param name="title">The title.</param>
        /// <param name="headBranch">The head branch.</param>
        /// <param name="baseBranch">The base branch.</param>
        /// <returns></returns>
        /// <exception cref="Exception">
        /// PAT token is required
        /// or
        /// Repository url is not valid to call api.
        /// or
        /// Error occurred {apiResponse.StatusCode}: {rawResponse}
        /// </exception>
        public string CreatePullRequest(string repositoryUrl, string title, string headBranch, string baseBranch)
        {
            if (string.IsNullOrWhiteSpace(_patToken))
            {
                throw new Exception("PAT token is required");
            }

            string[] splitUrl = repositoryUrl.Split('/');
            if (splitUrl.Length < 3)
            {
                throw new Exception("Repository url is not valid to call api.");
            }

            string owner = splitUrl[1].ToString();
            string repo = splitUrl[2].ToString();
            string apiUrl = $"https://api.github.com/repos/{owner}/{repo}/pulls";

            var data = new Dictionary<string, string>()
            {
                { "head" , headBranch },
                { "base" , baseBranch },
                { "title" , title }
            };

            var apiResponse = HttpHandler.SendRequest(apiUrl, HttpMethod.Post, _patToken, data: data, headers: _githubApiRequiredHeaders).Result;
            var rawResponse = apiResponse.Content.ReadAsStringAsync().Result;

            if (apiResponse.StatusCode == HttpStatusCode.OK)
            {
                return rawResponse;
            }

            throw new Exception($"Error occurred {apiResponse.StatusCode}: {rawResponse}");
        }

        /// <summary>
        /// Gets the branch names.
        /// </summary>
        /// <param name="repositoryUrl">The repository URL.</param>
        /// <returns></returns>
        /// <exception cref="Exception">
        /// PAT token is required
        /// or
        /// Repository url is not valid to call api.
        /// or
        /// Error occurred {apiResponse.StatusCode}: {rawResponse}
        /// </exception>
        public string GetBranchNames(string repositoryUrl)
        {
            if (string.IsNullOrWhiteSpace(_patToken))
            {
                throw new Exception("PAT token is required");
            }

            string[] splitUrl = repositoryUrl.Split('/');
            if (splitUrl.Length < 3)
            {
                throw new Exception("Repository url is not valid to call api.");
            }

            string owner = splitUrl[1].ToString();
            string repo = splitUrl[2].ToString();
            string apiUrl = $"https://api.github.com/repos/{owner}/{repo}/branchs";

            var apiResponse = HttpHandler.SendRequest(apiUrl, HttpMethod.Post, _patToken, headers: _githubApiRequiredHeaders).Result;
            var rawResponse = apiResponse.Content.ReadAsStringAsync().Result;

            if (apiResponse.StatusCode == HttpStatusCode.OK)
            {
                return rawResponse;
            }

            throw new Exception($"Error occurred {apiResponse.StatusCode}: {rawResponse}");
        }
    }
}
