var CategoryTree = (function ($) {

	var api = {
		config: {
			applicationKey: '',
			account: ''
		},

		functions: {
			SetConfig: function (key, email) {
				api.config = {
					applicationKey: key,
					account: email
				};
			}
		},

		CategoryTree: function () {
			var parameters = {};
			$.ajax({
				headers: {
					"Content-Type": "application/json",
					"Access-Control-Allow-Headers": "Access-Control-Allow-Headers, Origin,Accept, X-Requested-With, Content-Type, Access-Control-Request-Method, Access-Control-Request-Headers",
					"Access-Control-Allow-Methods": "GET,HEAD,OPTIONS,POST,PUT",
					"Access-Control-Allow-Origin": "*"
				},
				url: 'http://localhost:8081/chuck/categories',
				/*url: 'https://api.chucknorris.io/jokes/categories',*/
				data: parameters,
				type: 'GET',
				async: true,
				crossDomain: true,
				beforeSend: function () {
					//Loader
				},
				success: function (data) {
					// get the Categories

					if (data.length > 0) {

						var categories = data;
						$.each(categories, function (key, value) {
							$("#categoriesDiv").append(`<a href="/Search?joke=${value.name}" target="_blank">${value.name}</a><br/>`);
						});

					}
				},
				complete: function (data) {

				},
				error: function (data) {
					var t = data;
				}
			});
		}
	};

	var functions = {
		Initialise: function (applicationKey, email) {
			api.functions.SetConfig(applicationKey, email);
			api.CategoryTree();
		}
	};

	return {
		Functions: functions
	};

})(jQuery);
