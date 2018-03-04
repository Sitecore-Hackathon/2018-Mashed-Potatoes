![Hackathon Logo](documentation/images/hackathon.png?raw=true "Hackathon Logo")

# Product Reviews Module

## Module Purpose

One of the must have features of any commerce website is customer's reviews for the product. The module gives possibility to provide feedback using simple form on the product page.
Module extends Sitecore Commerce Engine capabilities.

## Module Sitecore Hackathon Category

Sitecore Commerce

## Prerequisites

Solution includes default Commerce Engine SDK projects: Plugin.Sample.AdventureWorks, Plugin.Sample.Habitat, Plugin.Sample.Upgrade.
As default installation has strong dependencies on these projects through configuration files we have considered to include them into repository.
The compiled solution is ready to deploy to Commerce Authoring service.

Solution depends on the Sitecore SXA Storefront Demo site. 

## Installation Guide
 
 - clone repository to local machine
 - open MashedPotatoes solution file with Visual Studion 2017
 - restore nuget packages for the solution
 - deploy Sitecore.Commerce.Engine project to local Sitecore Commerce Authoring service
 - install MashedPotatoesModule-1.0.zip to storefront site
 - publish site
 - enjoy :)
 
## Module usage

### Web site
To add reviews to the site use the following renderings:
/sitecore/layout/Renderings/Feature/MashedPotatoes/Feature/Reviews/Submit Review - to add and submit reviews
/sitecore/layout/Renderings/Feature/MashedPotatoes/Feature/Reviews/Reviews - to display reviews (in progress)

![sxa renderings params](documentation/images/sxa-renderings-params.png?raw=true "sxa renderings params")

![product reviews rendering](documentation/images/product-reviews-rendering.png?raw=true "product reviews rendering")

Here is the form to add reviews. User can fill out the form and submit the review.

![product details review form](documentation/images/product-details-review-form.png?raw=true "product details review form")

### Sitecore admin panel
Commerce manager can also see reviews in Sitecore Commerce Business Tools. There is a new tab called Reviews.

![sitecore commerce biz reviews](documentation/images/sitecore-commerce-biz-reviews.png?raw=true "sitecore commerce biz reviews")

Clicking on the reviews tab allows commerce manager to see all reviews for all products. 
Clicking on the product link will lead directly to the product information view.

![reviews all engine view](documentation/images/reviews-all-engine-view.png?raw=true "reviews all engine view")

Product information view contains reviews only for selected product.

![product review view](documentation/images/product-review-view.png?raw=true "product review view")

## Video
Video can be found here https://www.youtube.com/watch?v=bZgRxDJDLLo
