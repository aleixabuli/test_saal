import React, {ButtonHTMLAttributes, useState} from 'react';
import "./../styles/start_delivery.css";
export const ShowDeliveryComponent = () => {

    type OrderToDelivery = {
        productId: number;
        quantity: number;
    }

    var orderToDeliveryArray = [] as OrderToDelivery[]

    function findTheOrderByProductId(order: OrderToDelivery, prodId: number){
        return order.productId== prodId;
    }

    

    const startDelivery  = (e: React.MouseEvent<HTMLButtonElement>) => {
        let divProducts = document.getElementById("divProducts");
        let divBuy = document.getElementById("divBuy");
        let btnMakeOrder = document.getElementById("btnMakeOrder");
        if(divProducts && divBuy && btnMakeOrder){
            divProducts.hidden=false;
            divBuy.hidden=false;
            btnMakeOrder.hidden = false;
        }
        
        let button = e.target as HTMLButtonElement;
        button.hidden = true;
    }



    const productCheckboxChange  = (
        productId: string, 
        value: string, 
        checked:boolean) => 
    {

        let inputQuantity = document.getElementById("inputQuantityProduct_"+value) as HTMLInputElement;
        let divQuantityProductWithLabel = document.getElementById("divQuantityProductWithLabel_"+value) as HTMLDivElement;
        if(inputQuantity && divQuantityProductWithLabel){
            if(checked){
                inputQuantity.value = "1";
                inputQuantity.min = "1";
                inputQuantity.max = "100";
                divQuantityProductWithLabel.hidden = false;

                let orderToDelivery = 
                { 
                    productId: 1, quantity: parseInt(inputQuantity.value) 
                } as OrderToDelivery;
                orderToDeliveryArray.push(orderToDelivery)

            }else{
                inputQuantity.value = "0";
                inputQuantity.min = "0";
                inputQuantity.max = "0";
                divQuantityProductWithLabel.hidden = true;

                orderToDeliveryArray = orderToDeliveryArray.filter(order => order.productId!=parseInt(productId));
            }
        }
        
    }

    const onQuantityProductChange = () =>{
        
    }

    const createOrder  = () => {

    }

    return (
<div id="deliveryDiv">
    <div id="divBuyProcess">
        <button id="buttonStartDelivery" className="standardButton" onClick={e => startDelivery(e)}>Click here to start your delivery!</button>
        <div id="divProducts" hidden={true}>
            <article>
                <div className='divSuperiorArticle'>
                    <img src="https://cookinglsl.com/wp-content/uploads/2014/11/whole-roasted-chicken-with-potatoes-2-1.jpg" height={100} width={100} />
                    <div className='divQuantityProduct'>
                        <div className='divQuantityProductWithLabel' id="divQuantityProductWithLabel_1" hidden={true}>
                            <label>Quantity:</label>
                            <input type="number" defaultValue={0} min={0} max={0} id="inputQuantityProduct_1" onChange={onQuantityProductChange}/>
                        </div>
                    </div>
                </div>
                <input type="checkbox" id="product_1" value="1" onChange={e => productCheckboxChange(e.target.id, e.target.value, e.target.checked)}/>
                <label htmlFor="product_1">Chicken with potatoes</label>
            </article>

            
        </div>
        <div id="divBuy" hidden={true}>
            <button id="btnMakeOrder" className='standardButton' hidden={true} onClick={createOrder}>Make your order!</button>
        </div>
    </div>
    
</div>
    );
}