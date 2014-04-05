jQuery(function ($) {
	// Load dialog on click
	$('#lnkLocalizacao').click(function (e) {
		$('#basic-modal-content').modal({
		    opacity:75,
	        overlayCss: {backgroundColor:"#000"}
		});
		return false;
	});
	
	// Load dialog on click
	$('.lnkAlbumFotosEmpresa').click(function (e) {
		$('#basic-modal-content').modal({
		    opacity:75,
	        overlayCss: {backgroundColor:"#000"}
		});
		return false;
	});
});