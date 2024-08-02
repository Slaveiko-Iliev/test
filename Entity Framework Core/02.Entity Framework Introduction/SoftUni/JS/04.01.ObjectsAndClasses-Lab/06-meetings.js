function solve(input) {
    let meetingAppointments = {}

    for (const record of input) {
        let appointmentInfo = record.split(' ');
        
        const weekday = appointmentInfo[0];
        const name = appointmentInfo[1];

        if (meetingAppointments[weekday]){
            console.log(`Conflict on ${weekday}!`)
        } else {
            meetingAppointments[weekday] = name;
            console.log(`Scheduled for ${weekday}`);
        }
        
    }

    for (const record in meetingAppointments) {
        console.log(`${record} -> ${meetingAppointments[record]}`);
    }
    
}

solve(['Monday Peter',
'Wednesday Bill',
'Monday Tim',
'Friday Tim']
);

solve(['Friday Bob',
'Saturday Ted',
'Monday Bill',
'Monday John',
'Wednesday George']
);