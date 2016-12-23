var wiki = {
	toggleRecord: function(el, event){
		var $el = $(el);
		if($(event.target).closest('.wanna-list-child').length == 0){
			if($el.hasClass('active')){
				$el.toggleClass('active').find('.wanna-list-child').slideToggle(200);	
			} else {
				$('.wanna-list-parent-item').removeClass('active').find('.wanna-list-child').slideUp(200);
				$el.toggleClass('active').find('.wanna-list-child').slideDown(200);	
			}	
		}
		
	}
}
