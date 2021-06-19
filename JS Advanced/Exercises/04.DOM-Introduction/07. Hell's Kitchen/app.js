function solve() {
   document.querySelector('#btnSend').addEventListener('click', onClick);
   let textarea = document.querySelector('textarea');

   function onClick () {
      let restorants = JSON.parse(textarea.value)
                           .map(parseRestorant)
                           .reduce((obj, rest) => {
                              if(obj[rest.name]){
                                 Object.assign(obj[rest.name].workers, rest.workers);
                              }else{
                                 obj[rest.name] = rest;
                              }
                              return obj;
                           }, {});

      let all = Object.values(restorants);
      let bestrest = all.reduce((best, curr) => curr.averageSalary > best.averageSalary ? curr : best, all[0] );

      document.querySelector('#outputs #bestRestaurant p').textContent = 
         `Name: ${bestrest.name} Average Salary: ${bestrest.averageSalary.toFixed(2)} Best Salary: ${bestrest.bestSalary.toFixed(2)}`;

      document.querySelector('#outputs #workers p').textContent = 
         Array.from(Object.entries(bestrest.workers))
            .sort((a, b) => b[1] - a[1])
            .map(([name, salary]) => `Name: ${name} With Salary: ${salary}`)
            .join(' ');

      
      function parseRestorant(inputStr){
         let[name, workers] = inputStr.split(' - ');

         return {
            name,
            workers: workers.split(', ')
                              .map(x => x.split(' '))
                              .reduce((obj, [name, salary]) => {
                                 obj[name] = Number(salary);
                                 return obj;
                              }, {}),

            get averageSalary()  {
               let arrWorkers = Object.values(this.workers);
               return arrWorkers.reduce((a, x) => a + x, 0) / arrWorkers.length},

            get bestSalary() {
               let arrWorkers = Object.values(this.workers);
               return arrWorkers.reduce((best, salary) => salary > best ? salary : best, 0 )}
         }
      }
   }
}

["PizzaHut - Peter 500, George 300, Mark 800",
"TheLake - Bob 1300, Joe 780, Jane 660"]

"Name: {restaurant name} Average Salary: {restaurant avgSalary} Best Salary: {restaurant bestSalary}"

"Name: {worker name} With Salary: {worker salary} Name: {worker2 name} With Salary: {worker2 salary} Name: {worker3 name} With Salary: {worker3 salary}…"


