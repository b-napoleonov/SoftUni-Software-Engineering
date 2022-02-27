async function loadCommits() {
    const username = document.getElementById('username').value;
    const repo = document.getElementById('repo').value;
    const commitsUL = document.getElementById('commits');
    commitsUL.innerHTML = '';
    const url = `https://api.github.com/repos/${username}/${repo}/commits`;

    try {
        const response = await fetch(url);
        const commitsResult = await response.json();
        commitsResult.forEach(commit => {
            const liCommitInfo = document.createElement('li');
            liCommitInfo.textContent = `${commit.commit.author.name}: ${commit.commit.message}`;
            commitsUL.appendChild(liCommitInfo);
        });
    } catch (error) {
        const liCommitInfo = document.createElement('li');
        liCommitInfo.textContent = `Error: ${error.status} (Not Found)`;
        commitsUL.appendChild(liCommitInfo);
    }
}