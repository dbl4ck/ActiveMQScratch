# ActiveMQScratch

First hour of Using WebAPI2 with ActiveMQ for deferred processing.

Consists of:
* **ActiveMQScratch.Models** - Shared model library. containing a single model, *Order*
* **ActiveMQScratch.OrderSender** - Creates an Order model every second, posts to *api/orders*
* **ActiveMQScratch.OrderWeb** - Receives the Order model, publishes to Apache MQ
* **ActiveMQScratch.OrderReceiver** - Grabs the Order model, subscribes to Apache MQ and prints any new items to console.
