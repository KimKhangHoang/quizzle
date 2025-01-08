// Timer logic
function initializeQuizTimer(timeInMinutes, formSelector, timerSelector, submitButtonSelector) {
   let time = timeInMinutes * 60;

   const timerElement = document.querySelector(timerSelector);
   const formElement = document.querySelector(formSelector);
   const submitButton = document.querySelector(submitButtonSelector);

   function updateTimer() {
       const minutes = Math.floor(time / 60);
       const seconds = time % 60;

       // Format the time as MM:SS
       if (timerElement) {
           timerElement.textContent = `${minutes.toString().padStart(2, '0')}:${seconds.toString().padStart(2, '0')}`;
       }

       // Check if time is up
       if (time <= 0) {
           clearInterval(timerInterval);
           alert("Time is up! Submitting your answers.");
           if (submitButton) {
               submitButton.click(); // Forcefully trigger the submit button
           }
       }

       time--;
   }

   // Start the timer
   const timerInterval = setInterval(updateTimer, 1000);
}
