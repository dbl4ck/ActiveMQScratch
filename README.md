# Project Has Been Superceded by [Artemis-WebApi2-RequestReply](https://github.com/dbl4ck/Artemis-WebApi2-RequestReply) as of 28/04/2019


# ActiveMQScratch

First hour of Using WebAPI2 with ActiveMQ for deferred processing.

Consists of:
* **ActiveMQScratch.Models** - Shared model library. containing a single model, *Order*
* **ActiveMQScratch.OrderSender** - Console App, creates an Order model every second, posts to *api/orders* service
* **ActiveMQScratch.Web** - WebApi2 service, receives the Order model, publishes to Apache MQ
* **ActiveMQScratch.OrderReceiver** - Console App, subscribes to Apache MQ, grabs orders and prints to console.

Tested against a broker using a stock setup of [Apache ActiveMQ Artemis](https://activemq.apache.org/components/artemis/)

## Watch it go!

This is an example with one sender, one api instance, one broker, one listener.

![animation](https://raw.githubusercontent.com/dbl4ck/ActiveMQScratch/master/Docs/Images/animation-single.gif)

This is an example with two senders, one api instance, one broker, three listeners.

![animation](https://raw.githubusercontent.com/dbl4ck/ActiveMQScratch/master/Docs/Images/animation-multiple.gif)

# Changelog
11/04/2019: Receiver now implements listener pattern rather than a synchronous loop. Asynchrony++
