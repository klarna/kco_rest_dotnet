<%@ Page Language="C#" Inherits="WebForms.Default" Async="true" %>
<!doctype html>
<html lang="en">

<head runat="server">
    <title>Klarna Checkout Example: Shopping Cart</title>

    <!-- Required meta tags -->
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">

    <!-- Bootstrap CSS -->
    <link rel="stylesheet" href="res/css/bootstrap.min.css"
        integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T" crossorigin="anonymous">
</head>

<body>
    <div class="container">
        <div class="row justify-content-center">
            <div class="col-4">
                <div class="card" style="width: 18rem;">
                    <figure class="figure card-body">
                        <img src="res/img/tomato-bunch-mature-red-48802.jpeg" class="figure-img img-fluid rounded"
                            alt="5 Red Cherry Tomatoes by https://www.pexels.com/@pixabay">
                        <figcaption class="figure-caption">Image from <a
                                href="https://www.pexels.com/photo/5-red-cherry-tomatoes-48802/">www.pexels.com</a>
                        </figcaption>
                    </figure>

                    <div class="card-body">
                        <h5 class="card-title">Tomatoes</h5>
                        <p class="card-text">A bright red tomato. Size of uncut tomato is approx 10cm in diameter</p>
                        <p><strong>10 kg</strong></p>
                        <a href="#" class="btn btn-secondary">Go to details</a>
                        <a href="#" class="btn btn-danger">Delete</a>
                    </div>
                </div>
            </div>
            <div class="col-4">
                <div class="card" style="width: 18rem;">
                    <figure class="figure card-body">
                        <img src="res/img/pexels-photo-2116020.jpeg" class="figure-img img-fluid rounded"
                            alt="Ripe Bananas by https://www.pexels.com/@renata-brant-1119012">
                        <figcaption class="figure-caption">Image from <a
                                href="https://www.pexels.com/photo/ripe-bananas-2116020/">www.pexels.com</a>
                        </figcaption>
                    </figure>
                    <div class="card-body">
                        <h5 class="card-title">Bananas</h5>
                        <p class="card-text">Bananas box package</p>
                        <p><strong>1 box pack</strong></p>
                        <a href="#" class="btn btn-secondary">Go to details</a>
                        <a href="#" class="btn btn-danger">Delete</a>
                    </div>
                </div>
            </div>
            <div class="col-4">
                <h3>Shopping cart</h3>
                <table class="table">
                    <tbody>
                        <tr>
                            <th scope="row">10 x Tomatoes</th>
                            <td>60 &pound;</td>
                        </tr>
                        <tr>
                            <th scope="row">1 x Box Bananas</th>
                            <td>40 &pound;</td>
                        </tr>

                        <tr class="table-primary">
                            <th scope="col">Total</th>
                            <th scope="col">100 &pound;</th>
                        </tr>
                    </tbody>
                </table>
                <form id="form1" runat="server">
                    <asp:Button id="button_next" class="btn btn-success" runat="server" Text="Checkout"
                        OnClick="checkoutClicked" />
                </form>
            </div>
        </div>
    </div>
</body>

</html>