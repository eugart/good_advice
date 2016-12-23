ymaps.ready(init);

function init() {
	//создание карты
    var geolocation = ymaps.geolocation,
        myMap = new ymaps.Map('map', 
		{
            center: [54.16, 45.16],
            zoom: 14,
			controls: []
        });

	//создание строки поиска
	var searchControl = new ymaps.control.SearchControl(
	{
        options: 
		{
            provider: 'yandex#search',
			float: 'right'
        }
    });

	myMap.controls.add('zoomControl', {position: {right: '10px', top: '100px'}});
	myMap.controls.add(searchControl);
	searchControl.search('АвтоМойка');
}