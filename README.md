# Optimising electricity consumption

Welcome to the Delivery Emissions live coding exercise for HIVED, the eco-friendly delivery company :truck::recycle:

At HIVED, we will never use fossil fuels, so all our vans are electric. :zap:
But different sizes of vans will vary in their electricity consumption, and so it's better for the planet (and for our wallet! :money_with_wings:) to carefully select which vans are used for which delivery routes.

## Exercise

We'd like you to write a program that assigns vehicles to routes, in a way that will minimise electricity consumption (in kWh).

### Input

1. `routes.json` This contains an array of different routes. Each route will have an ID and a list of stops. Each stop will have a distance from the previous stop in kilometers.

2. `vehicles.json` This contains an array of vehicles. Each vehicle will have an ID, a capacity in kWh, and an average electricity consumption in kWh/100km.

### Output

As an output, we'd like to see:

* The list of optimal vehicle-route pairs
* The total kWh required to complete all routes sequentially using the least efficient vehicle only
* The total kWh required to complete all routes in parallel using the optimal vehicle-route pairs

## Instructions

### For live sessions

* :speech_balloon: See this exercise as an interactive session, ask us questions as you would if we were working together
* :ok_hand: Aim to write code in the way you would every day - **you will not be penalised if you don't complete the exercise**


### For take-homes

* :pencil2: Feel free to reach out to ask for clarifications and document your assumptions
* :ok_hand: Aim to write code in the way you would every day - we expect you to complete the exercise


### Assumptions I have made

Optimal Pairing Assumption: The assumption was made that the optimal pairs are formed by assigning the larger energy-consuming vehicles to the routes with the shortest distances, with the goal of minimizing the total energy consumption.

Vehicle Energy Consumption Consistency: An assumption was made that the energy consumption values (kWh per 100 km) provided for the vehicles are accurate and consistent across all vehicles, without variations or deviations.

Sequential Consumption Assumption: It was assumed that the "Total kWh for sequential use using the least efficient vehicle" corresponds to the vehicle with the highest kWh per 100 km, representing the least energy-efficient vehicle in the fleet.

Parallel Consumption Calculation Assumption: The calculation of the total energy consumption when all the routes are completed in parallel, as performed in the CalculateParallelConsumption method, is based on the assumption that optimal vehicle-route pairs have been assigned. This calculation sums up the energy consumption of each assigned pair, which includes both the vehicle and the route. The result is rounded to 2 decimal places. This assumption underlines the approach of calculating parallel energy consumption based on the assigned pairs and acknowledges the rounding for precision.