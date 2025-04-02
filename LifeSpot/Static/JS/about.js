function getComment() {
    let comment = {}
    comment.author = prompt("Как вас зовут ?")
    if (comment.author == null) {
        return
    }

    comment.text = prompt("Оставьте отзыв")
    if (comment.text == null) {
        return
    }

    comment.date = new Date().toLocaleString()

    let enableLikes = confirm('Разрешить пользователям оценивать ваш отзыв?')

    if (enableLikes) {
        let review = Object.create(comment)
        review.rate = 0;
        writeReview(review)
    } else {
        writeReview(comment)
    }
}

const writeReview = review => {
    let likeCounter = '';

    if (review.hasOwnProperty('rate')) {
        let commentId = Math.random();
        likeCounter += '<button id="' + commentId + '" style="border: none" onclick="addLike(this.id)">' + `❤️ ${review.rate}</button>`
    }
    document.getElementsByClassName('reviews')[0].innerHTML += ' <div class="review-    text">\n' + `<p> <i> <b>${review['author']}</b> ${review['date']}${likeCounter}</i></p>` + `<p>${review['text']}</p>` + '</div>';
}


function Comment() {
    this.author = prompt("Как вас зовут ?")
    if (this.author == null) {
        this.empty = true
        return
    }
    this.text = prompt("Оставьте отзыв")
    if (this.text == null) {
        this.empty = true
        return
    }
    this.date = new Date().toLocaleString()
}

function addComment() {
    let comment = new Comment()
    if (comment.empty) {
        return;
    }

    let enableLikes = confirm('Разрешить пользователям оценивать ваш отзыв?')

    if (enableLikes) {
        let review = Object.create(comment)
        review.rate = 0;
        writeReview(review)
    } else {
        writeReview(comment)
    }
}

function addLike(id) {
    let element = document.getElementById(id);
    let array = element.innerText.split(' ')
    let resultNum = parseInt(array[array.length - 1], 10);
    resultNum += 1
    array[array.length - 1] = `${resultNum}`
    element.innerText = array.join(' ')
}

var slideIndex = 1;

document.addEventListener('DOMContentLoaded', () => {
    showSlides(slideIndex);
})

function nextSlide() {
    showSlides(slideIndex += 1);
}

function prevSlide() {
    showSlides(slideIndex -= 1);
}

function showSlides(n) {
    var i;
    var slides = document.getElementsByClassName("myslides");
    var dots = document.getElementsByClassName("dot");

    if (n > slides.length) {
        n = 1;
        slideIndex = 1;
    }
    if (n < 1) {
        n = slides.length
        slideIndex = slides.length;
    }
    
    for (i = 0; i < slides.length; i++) {
        slides[i].style.display = "none";
    }
    for (i = 0; i < dots.length; i++) {
        dots[i].className = dots[i].className.replace("active", "");
    }

    slides[n - 1].style.display = "block";
    dots[n - 1].classList.add("active");
}