# Linq & EF Project

## Project Overview

This project is a management system for a commercial company's warehouses, items, customers, and suppliers. It utilizes Linq and Entity Framework for data access and manipulation. The system allows users to perform various operations related to store, category, resource, customer, supply permit, exchange permit, and more.

## Features

1. **Store Management:**
   - Add/modify a store.
   - Generate reports on each store separately with an optional specified period.

2. **Category Management:**
   - Add/modify a category.

3. **Resource Management:**
   - Add/edit a resource.

4. **Customer and Supplier Management:**
   - Add/edit a customer or supplier.

5. **Permit Management:**
   - Add/edit a supply permit, including warehouse name, permit number, permit date, items, quantity, supplier name, production date, and expiration period.
   - Add/edit an exchange permit, including store name, permission number, date of authorization, items, quantity, and supplier name.

6. **Item Transfer:**
   - Transfer a group of items from one store to another, specifying from, to, item, quantity, supplier, production and expiry date.

7. **Reports:**
   - Generate reports on each item (in one or more specified warehouses) with an optional specified period.
   - Generate a report on the movement of items in a specific period (in one or more specified warehouses).
   - Generate a report on items that have been in the warehouse for a specified period of time.
   - Generate a report on items that are close to expiring (determined by the remaining expiration time).

