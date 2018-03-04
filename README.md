![Hackathon Logo](documentation/images/hackathon.png?raw=true "Hackathon Logo")

# Product Reviews Module

## Module Purpose

One of the must have features of any commerce website is customer's review on the product. Our module allows to provide feedback using simple form on the product page.
Module extends Sitecore Commerce Engine capabilities.

## Module Sitecore Hackathon Category

Sitecore Commerce

## Prerequisites

Solution includes default Commerce Engine SDK projects: Plugin.Sample.AdventureWorks, Plugin.Sample.Habitat, Plugin.Sample.Upgrade.
As default installation has strong dependencies on this projects through configuration files we have considered to include them into repository.
The compiled solution is ready to deploy to Commerce Authoring service.

## Installation Guide

 - clone repository to your machine
 - open MashedPotatoes solution file with Visual Studion 2017
 - restore nuget packages for the solution
 - deploy Sitecore.Commerce.Engine project to your local Sitecore Commerce Authoring service
 
## Module usage

### Web site
To add reviews to your site use the following renderins:
/sitecore/layout/Renderings/Feature/MashedPotatoes/Feature/Reviews/Submit Review - to add and submit reviews
/sitecore/layout/Renderings/Feature/MashedPotatoes/Feature/Reviews/Reviews - to display rewiews (in progress)

![sxa renderings params](documentation/images/sxa-renderings-params.png?raw=true "sxa renderings params")

![product reviews rendering](documentation/images/product-reviews-rendering.png?raw=true "product reviews rendering")

Here is the form to add reviews. You can fill out fields and submit your review.

![product details review form](documentation/images/product-details-review-form.png?raw=true "product details review form")

### Sitecore admin panel
You can also see reviews in Sitecore Commerce Business Tools. To do this open Commerce Business Tools. 
You will see new tab called Reviews. 

![sitecore commerce biz reviews](documentation/images/sitecore-commerce-biz-reviews.png?raw=true "sitecore commerce biz reviews")

If you click on the reviews tab, you will be able to see all reviews for all products. 
Moreover, you can click on the product link and you will be redirected directly on the product page.
![reviews all engine view](documentation/images/reviews-all-engine-view.png?raw=true "reviews all engine view")

On the product page you will see reviews only for current product.
![product review view](documentation/images/product-review-view.png?raw=true "product review view")

## Video
Video can be found here https://www.youtube.com/watch?v=bZgRxDJDLLo
