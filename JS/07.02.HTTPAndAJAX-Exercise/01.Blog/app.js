function attachEvents() {
    const baseURL = `http://localhost:3030/jsonstore/blog`;

    const btnLoadPostsElement = document.getElementById(`btnLoadPosts`);
    const postsElement = document.getElementById('posts');
    const btnViewPostElement = document.getElementById('btnViewPost');
    const postCommentsElement = document.getElementById('post-comments');
    const postTitleElement = document.getElementById('post-title');
    const postBodyElement = document.getElementById('post-body');

    btnLoadPostsElement.addEventListener('click', async function getPosts() {
        try {
            const response = await fetch(`${baseURL}/posts`);
            const posts = await response.json();
            const postsValues = Object.values(posts);

            const optionElementsFragment = document.createDocumentFragment();

            for (const potstValue of postsValues) {
                const optionElement = document.createElement('option');
                optionElement.value = potstValue.id;
                optionElement.textContent = potstValue.title;
                optionElementsFragment.appendChild(optionElement);
            }

            postsElement.appendChild(optionElementsFragment);
        } catch (error) {
            console.log(`Vai, vai error`);
        }
      });

    btnViewPostElement.addEventListener('click', async () => {
        try {
            const response = await fetch(`${baseURL}/comments`);
            const comments = await response.json();
            const currentCommentsValues = Object.values(comments)
                .filter(comment => comment.postId === postsElement.value);

            
            // const liElementsFragment = document.createDocumentFragment();
            postCommentsElement.innerHTML = ``;

            for (const currentCommentValue of currentCommentsValues) {
                const liElement = document.createElement('li');
                liElement.textContent = currentCommentValue.text;
                liElement.id = currentCommentValue.id;
                // liElementsFragment.appendChild(liElement);
                postCommentsElement.appendChild(liElement);
            }

            const selectedPostId = postsElement.value;
            const responseSelectedPostId = await fetch(`${baseURL}/posts/${selectedPostId}`);
            const selectedPost = await responseSelectedPostId.json();
            
            postTitleElement.textContent = selectedPost.title;
            postBodyElement.textContent = selectedPost.body;

            // postCommentsElement.innerHTML = ``;
            // postCommentsElement.appendChild(liElementsFragment);

        } catch (error) {
            
        }
    });
}

attachEvents();



// function attachEvents() {
//     const postsURL = 'http://localhost:3030/jsonstore/blog/posts'
//     const commentsURL = 'http://localhost:3030/jsonstore/blog/comments'

//     let loadPostsButton = document.getElementById('btnLoadPosts')
//     loadPostsButton.addEventListener('click', loadPostsEvent)

//     let postsSelect = document.getElementById('posts')

//     let viewPostButton = document.getElementById('btnViewPost')
//     viewPostButton.addEventListener('click', viewPostEvent)

//     allPosts = {}

//     async function loadPostsEvent(event) {
//         postsSelect.innerHTML = ''
//         let allPostsResponse = await fetch(postsURL)
//         allPosts = await allPostsResponse.json()
        
//         for (let postArr of Object.entries(allPosts)) {
//             let option = document.createElement('option')
//             option.textContent = postArr[1].title
//             option.value = postArr[0]
//             postsSelect.appendChild(option)
//         }
//     }

//     async function viewPostEvent(event) {
//         let currentPostObject = document.getElementById('posts')
//         let currentPostComments = []

//         let allCommentsResponse = await fetch(commentsURL)
//         let allComments = await allCommentsResponse.json()
        
//         for (let commentArr of Object.entries(allComments)) {
//             if (commentArr[1].postId === currentPostObject.value) {
//                 currentPostComments.push(commentArr[1].text)
//             }
//         }

//         let chosenPost = allPosts[currentPostObject.value]
    
//         let titleElement = document.getElementById('post-title')
//         titleElement.textContent = chosenPost.title

//         let postContentElement = document.getElementById('post-body')
//         postContentElement.textContent = chosenPost.body

//         let ul = document.getElementById('post-comments')
//         ul.innerHTML = ''
//         for (let comment of currentPostComments) {
//             let li = document.createElement('li')
//             li.textContent = comment
//             ul.appendChild(li)
//         }
//     }
// }

// attachEvents();