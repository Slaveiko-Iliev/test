function attachEventsListeners() {
    const convertDaysToHours  = days => {return days*24};
    const convertHoursToMInutes  = hours => {return hours*60};
    const convertMinutesToSeconds  = minutes => {return minutes*60};

    const convertSecondsToMinutes  = seconds => {return seconds/60};
    const convertMinutesToHours  = minutes => {return minutes/60};
    const convertHoursToDays  = hours => {return hours/24};
    
    const daysInputElement = document.getElementById('days');
    const hoursInputElement = document.getElementById('hours');
    const minutesInputElement = document.getElementById('minutes');
    const secondsInputElement = document.getElementById('seconds');

    const daysBtnElement = document.getElementById('daysBtn');
    const hoursBtnElement = document.getElementById('hoursBtn');
    const minutesBtnElement = document.getElementById('minutesBtn');
    const secondsBtnElement = document.getElementById('secondsBtn');

    // function clearData(){
    //     daysInputElement.value = '';
    //     hoursInputElement.value = '';
    //     minutesInputElement.value = '';
    //     secondsInputElement.value = '';
    // }
    
    daysBtnElement.addEventListener('click', () => {
        hoursInputElement.value = convertDaysToHours(daysInputElement.value);
        minutesInputElement.value = convertHoursToMInutes(convertDaysToHours(daysInputElement.value));
        secondsInputElement.value = convertMinutesToSeconds(convertHoursToMInutes(convertDaysToHours(daysInputElement.value)));
    })

    hoursBtnElement.addEventListener('click', () => {
        daysInputElement.value = convertHoursToDays(hoursInputElement.value);
        minutesInputElement.value = convertHoursToMInutes(hoursInputElement.value);
        secondsInputElement.value = convertMinutesToSeconds(convertHoursToMInutes(hoursInputElement.value));
    })

    minutesBtnElement.addEventListener('click', () => {
        daysInputElement.value = convertDaysToHours(convertMinutesToHours(minutesInputElement.value));
        hoursInputElement.value = convertMinutesToHours(minutesInputElement.value);
        secondsInputElement.value = convertMinutesToSeconds(minutesInputElement.value);
    })
    secondsBtnElement.addEventListener('click', () => {
        daysInputElement.value = convertHoursToDays(convertMinutesToHours(convertSecondsToMinutes(secondsInputElement.value)));
        hoursInputElement.value = convertMinutesToHours(convertSecondsToMinutes(secondsInputElement.value));
        minutesInputElement.value = convertSecondsToMinutes(secondsInputElement.value);
        
    })
}
