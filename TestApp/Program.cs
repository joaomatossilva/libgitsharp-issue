namespace TestApp
{
    using LibGit2Sharp;

    class Program
    {
        static void Main(string[] args)
        {
            using (var repo = new Repository("."))
            {

                var remoteRefName = "refs/remotes/origin/master";
                var branchName = "master";

                var remoteBranch = repo.Branches[remoteRefName];

                var localBranch = repo.Branches[branchName];
                if (localBranch == null)
                {
                    localBranch = repo.CreateBranch(branchName, remoteBranch.Tip);
                }

                repo.Branches.Update(localBranch, b =>
                {
                    b.TrackedBranch = remoteBranch.CanonicalName;
                });
            }
        }
    }
}
