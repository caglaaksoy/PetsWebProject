(function ($) {
    "use strict";
  
      
    $(window).on('scroll', function () {
      var window_top = $(window).scrollTop() + 1;
      if (window_top > 50) {
        $('.site-navigation').addClass('menu_fixed animated fadeInDown');
      } else {
        $('.site-navigation').removeClass('menu_fixed animated fadeInDown');
      }
    });
  
      // SCROLL TO TOP
      
      $(window).on('scroll', function () {
          if ($(window).scrollTop() > 70) {
              $('.scroll-to-top').addClass('reveal');
          } else {
              $('.scroll-to-top').removeClass('reveal');
          }
      });
  
  
   
  $('.testimonial-slider').slick({
          slidesToShow: 2,
          infinite: true,
          arrows: false,
          autoplay: true,
          autoplaySpeed: 4000,
          vertical:true,
          verticalSwiping:true
      });
  
   /* ---------------------------------------------
           owl-carousel
  --------------------------------------------- */
  
      $('.clients-carousel').owlCarousel({
          loop:false,
          margin:10,
          autoplay:true,
          nav:false,
          dots:false,
          responsive:{
              0:{
                  items:1,
              },
              600:{
                  items:3,
              },
              1000:{
                  items:5,
              }
          }
      })
  
   
      $('.review').owlCarousel({
          loop:true,
          margin:10,
          autoplay:false,
          nav:true,
          navText: ["<i class='fa fa-chevron-left'></i>","<i class='fa fa-chevron-right'></i>"],
          dots:false,
          responsive:{
              0:{
                  items:1,
              },
              600:{
                  items:3,
              },
              1000:{
                  items:2,
              }
          }
      })
  
  
      // Counter
  
      $('.counter').counterUp({
            delay: 10,
            time: 1000
        });
  
      
  
  }(jQuery));