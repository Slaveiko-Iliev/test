function solve() {
   document.querySelector('#btnSend').addEventListener('click', onClick);

   function onClick () {
      const inputTextareaElementValue = document.querySelector('#inputs textarea').value;
      const bestRestaurantPElement = document.querySelector('#bestRestaurant p');
      const workersPElement = document.querySelector('#workers p');

      let restaurantsInfo = inputTextareaElementValue
         .match(/"(.*?)"/gm)
         .map(restaurant => restaurant.slice(1,restaurant.length-1))
         .map(restaurant => restaurant.split(' - '));

      let restaurants = {};
      
      for (let i = 0; i < restaurantsInfo.length; i++) {
         const restaurantName = restaurantsInfo[i][0];
         const workersInfo = restaurantsInfo[i][1]
            .split(', ')
            .map(worker => worker.split(' '));

         let workers = {};

         for (const [workerName, salary] of workersInfo) {
            workers[workerName] = Number(salary);
         }

         restaurants[restaurantName] = workers;
      }

      let bestRestaurant = {};
      let bestRestaurantName = {};
      let maxAverageSalary = Number.MIN_SAFE_INTEGER;
      let bestSalary = 0;
      

      for (const restaurant in restaurants) {
         let restaurantValue = Object.values(restaurants[restaurant]);

         let averageSalary = () => restaurantValue
            .reduce((a, b) => a + b, 0)/restaurantValue.length;

         
         let currentBestSalary = Math.max(...restaurantValue);

         if(averageSalary().toFixed(2) > maxAverageSalary){
            maxAverageSalary = averageSalary().toFixed(2);
            bestRestaurant = restaurants[restaurant];
            bestSalary = currentBestSalary.toFixed(2);
            bestRestaurantName = restaurant;
         }
      }

      bestRestaurantPElement.textContent = `Name: ${bestRestaurantName} Average Salary: ${maxAverageSalary} Best Salary: ${bestSalary}`;
      workersPElement.textContent = ``;

      for (const worker in bestRestaurant) {
         if(workersPElement.textContent.length === 0){
            workersPElement.textContent = `Name: ${worker} With Salary: ${bestRestaurant[worker]}`;
         } else {
            workersPElement.textContent += ` Name: ${worker} With Salary: ${bestRestaurant[worker]}`
         }
      }
      console.log(workersPElement.textContent);
   }
}