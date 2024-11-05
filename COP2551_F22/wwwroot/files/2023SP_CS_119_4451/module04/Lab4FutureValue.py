#!/usr/bin/env python3

# Cuyamaca College CS-119
# name: [your name goes here]
# Lab 4 future value


# variables and constants
monthly_deposit = 0.0
years = 0
annual_int_rate = 0.0
monthly_int_rate = 0.0
balance = 0.0
months = 0
month_number = 1

interest = 0.0
total_interest = 0.0

# input - get monthly deposit, period and interest rate
print()
monthly_deposit = float(input("Enter monthly deposit: "))
annual_int_rate = float(input("Enter annual percentage yield (APY): "))
years = int(input("Enter the duration of the investment in years: "))

# process
monthly_int_rate = annual_int_rate / 12 / 100
months = years * 12

# print statement header
print(f"\n\n${monthly_deposit:7.2f} per month", end=' ')
print(f"at {annual_int_rate:5.2f}% over {months:d}\n")
print("Mo. | Interest |   Deposit  |   Balance")

# update each month
while month_number <= months:
    balance += monthly_deposit
    interest = balance * monthly_int_rate
    total_interest += interest
    balance += interest

    print(f" {month_number:2d} | ${interest:7.2f} | ${monthly_deposit:9.2f} | ${balance:10.2f}")
    month_number += 1

# print summary
print(f"\n\nEnding Balance: ${balance:10.2f}", )
print(f"Total Interest: ${total_interest:10.2f}", )

print()
