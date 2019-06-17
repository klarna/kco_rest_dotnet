<%@ Page Language="C#" Inherits="WebForms.Default" Async="true" %>
<!doctype html>
<html lang="en">

<head runat="server">
    <title>Klarna Checkout Example: Shopping Card</title>

    <!-- Required meta tags -->
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">

    <!-- Bootstrap CSS -->
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T" crossorigin="anonymous">
</head>

<body>
    <div class="container">
        <div class="row justify-content-center">
            <div class="col-4">
                <div class="card" style="width: 18rem;">
                    <figure class="figure card-body">
                        <img src="https://upload.wikimedia.org/wikipedia/commons/thumb/8/88/Bright_red_tomato_and_cross_section02.jpg/320px-Bright_red_tomato_and_cross_section02.jpg" class="figure-img img-fluid rounded" alt="">
                        <figcaption class="figure-caption">Image from <a href="https://commons.wikimedia.org/wiki/File:Bright_red_tomato_and_cross_section02.jpg">Wikimedia</a> site. </figcaption>
                    </figure>

                    <div class="card-body">
                        <h5 class="card-title">Tomatoes</h5>
                        <p class="card-text">A bright red tomato. Size of uncut tomato is approx 10cm in diameter</p>
                        <p><strong>10 kg</strong></p>
                        <a href="#" class="btn btn-secondary">Go to details</a>
                    </div>
                </div>
                <div class="card" style="width: 18rem;">
                    <figure class="figure card-body">
                        <img src="https://upload.wikimedia.org/wikipedia/commons/thumb/4/44/Bananas_white_background_DS.jpg/320px-Bananas_white_background_DS.jpg" class="figure-img img-fluid rounded" alt="Augustus Binu">
                        <figcaption class="figure-caption">Image from <a href="https://commons.wikimedia.org/wiki/File:Bananas_white_background_DS.jpg">Wikimedia</a> site. (c) Augustus Binu</figcaption>
                    </figure>
                    <div class="card-body">
                        <h5 class="card-title">Bananas</h5>
                            <p class="card-text">Bananas box package</p>
                        <p><strong>1 box pack</strong></p>
                        <a href="#" class="btn btn-secondary">Go to details</a>
                    </div>
                </div>
            </div>
            <div class="col-4">
                <table class="table">
                    <tbody>
                        <tr>
                            <th scope="row">10 x Tomatoes</th>
                            <td>60 £</td>
                        </tr>
                        <tr>
                            <th scope="row">1 x Box Bananas</th>
                            <td>40 £</td>
                        </tr>

                        <tr class="table-primary">
                            <th scope="col">Total</th>
                            <th scope="col">100 £</th>
                        </tr>
                    </tbody>
                </table>
                <form id="form1" runat="server">
                    <asp:Button id="button_next" class="btn btn-success" runat="server" Text="Checkout" OnClick="checkoutClicked" />
                </form>
            </div>
        </div>
    </div>

    <footer class="footer mt-auto py-3">
        <div class="container text-center">
            <span class="text-muted">
        Wikimedia CC 3.0 <a href="https://creativecommons.org/licenses/by-sa/3.0/">License</a>
                and <a href="https://wiki.creativecommons.org/wiki/License_Versions#Detailed_attribution_comparison_chart">Attribution info</a>
    </span>
        </div>
    </footer>

    <!-- Optional JavaScript -->
    <!-- jQuery first, then Popper.js, then Bootstrap JS -->
    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js" integrity="sha384-UO2eT0CpHqdSJQ6hJty5KVphtPhzWj9WO1clHTMGa3JDZwrnQq4sF86dIHNDz0W1" crossorigin="anonymous"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js" integrity="sha384-JjSmVgyd0p3pXB1rRibZUAYoIIy6OrQ6VrjIEaFf/nJGzIxFDsf4x0xIM+B07jRM" crossorigin="anonymous"></script>
</body>

</html>