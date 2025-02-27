let age = prompt("Please enter your age:");

if (age >= 18) {
    alert("Welcome on Lifespot! " + new Date().toLocaleString());
}
else {
    alert("Viewer discretion is advised for people under 18. Redirecting...");
    window.location.href = "http://www.google.com"
}