function attachEvents() {
    const baseURL = `http://localhost:3030/jsonstore/blog`;

    const btnLoadPostsElement = document.getElementById(`btnLoadPosts`);

    btnLoadPostsElement.addEventListener('click', () => {
        async function getPosts() {
            try {
                const response = await fetch(`${baseURL}/posts`);
            const posts = await response.json();
            console.log(Object.keys(posts));
            } catch (error) {
                console.log(`Vai, vai error`);
            }
          }
        
        console.log(getPosts());
    });
}

attachEvents();