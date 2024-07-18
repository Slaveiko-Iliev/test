function checkSign(numOne, numTwo, numThree) {
    let isResultPositive = true;
    const isNumOnePositive = numOne >= 0;
    const isNumTwoPositive = numTwo >= 0;
    const isNumThreePositive = numThree >= 0;

    if (!isNumOnePositive){
        isResultPositive = !isResultPositive;
    }
    
    if (!isNumTwoPositive){
        isResultPositive = !isResultPositive;
    }
    
    if (!isNumThreePositive){
        isResultPositive = !isResultPositive;
    }

    if (isResultPositive){
        console.log (`Positive`);
    } else {
        console.log (`Negative`);
    }
}

checkSign( 5,
    12,
   -15
   );
checkSign( -6,
    -12,
     14
   );
checkSign( -1,
    -2,
    -3
    
   );