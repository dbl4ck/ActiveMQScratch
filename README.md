# ActiveMQScratch

First hour of Using WebAPI2 with ActiveMQ for deferred processing.

Consists of:
* **ActiveMQScratch.Models** - Shared model library. containing a single model, *Order*
* **ActiveMQScratch.OrderSender** - Console App, creates an Order model every second, posts to *api/orders* service
* **ActiveMQScratch.Web** - WebApi2 service, receives the Order model, publishes to Apache MQ
* **ActiveMQScratch.OrderReceiver** - Console App, subscribes to Apache MQ, grabs orders and prints to console.

Tested against a broker using a stock setup of [Apache Artemis](https://activemq.apache.org/components/artemis/)

## Watch it go!

This is an example with two listeners, one api instance, one broker, three liseners.

![animation](https://raw.githubusercontent.com/dbl4ck/ActiveMQScratch/master/Docs/Images/animation.gif)
