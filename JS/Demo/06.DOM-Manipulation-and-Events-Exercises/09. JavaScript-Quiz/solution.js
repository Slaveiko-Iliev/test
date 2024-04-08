function solve() {
    const quizAnswerElements = document.querySelectorAll('.quiz-answer');

    const questions = {
        'Question #1: Which event occurs when the user clicks on an HTML element?': 'onclick',
        'Question #2: Which function converting JSON to string?': 'JSON.stringify()',
        'Question #3: What is DOM?': 'A programming API for HTML and XML documents',
    }

    let answeredQuestions = 0;
    for (const answerElement of quizAnswerElements) {
        answerElement.addEventListener('click', (e) => {
            const sectionElement = e.currentTarget.parentElement.parentElement;
            const questionTitle = sectionElement.querySelector('.question h2').textContent;
            const answerText = answerElement.querySelector('.answer-text').textContent;

            if (questions[questionTitle] == answerText) {
                answeredQuestions++;
            }

            const nextSection = sectionElement.nextElementSibling ;
            sectionElement.classList.add('hidden');
            sectionElement.style.display = 'none';
            nextSection.classList.remove('hidden');
            nextSection.style.display = 'block';

            if (nextSection.id === 'results') {
                const headingElement = nextSection.querySelector('.results-inner h1');
                
                if (answeredQuestions === 3) {
                    headingElement.textContent = 'You are recognized as top JavaScript fan!'
                } else {
                    headingElement.textContent = `You have ${answeredQuestions} right answers`
                }
            }
        });
    }
}
