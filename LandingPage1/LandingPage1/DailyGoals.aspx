<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="DailyGoals.aspx.vb" Inherits="LandingPage1.DailyGoals" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="Content/horizontalTimeline-reset.css" rel="stylesheet" />
    <link href="Content/horizontalTimeline-style.css" rel="stylesheet" />
    <link href='https://fonts.googleapis.com/css?family=Playfair+Display:700,900|Fira+Sans:400,400italic' rel='stylesheet' type='text/css'>    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Daily Goals</h1>
    <section class="cd-horizontal-timeline">
	<div class="timeline">
		<div class="events-wrapper">
			<div class="events">
                <ol id="oTimeLine" runat="server"></ol>      
				<span class="filling-line" aria-hidden="true"></span>
			</div> <!-- .events -->
		</div> <!-- .events-wrapper -->			
		<ul class="cd-timeline-navigation">
			<li><a href="#0" class="prev inactive">Prev</a></li>
			<li><a href="#0" class="next">Next</a></li>
		</ul> <!-- .cd-timeline-navigation -->
	</div> <!-- .timeline -->
	<div class="events-content">
		<ol id="oScrollContent" runat="server"></ol>
	</div> <!-- .events-content -->
</section>
	
<script src="Scripts/horizontalTimeline.js"></script>
<script>

    $('disabled').on('click', function (e) { e.preventDefault(); });
    $('disabled').click(function (e) {
        $(this)
           .css('cursor', 'default')
           .css('text-decoration', 'none')

        if (!preventClick) {
            $(this).html($(this).html() + ' lalala');
        }

        preventClick = true;

        return false;
    });
</script>  

<!-- Resource jQuery -->
</asp:Content>
