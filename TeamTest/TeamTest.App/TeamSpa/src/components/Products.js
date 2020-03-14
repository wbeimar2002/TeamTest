import axios from 'axios'
import React, {Component} from 'react';
import * as commonConstants from '../common/constants'
import {Card, ListGroup, ListGroupItem} from 'react-bootstrap';

class Products extends Component{
    state = {
        prods: []
    }

    componentDidMount(){
        const uri = commonConstants.baseApiUrl+commonConstants.productsResource;
        axios.get(uri)
            .then(res => {
            const prods = res.data;
            this.setState({ prods });
            console.log(prods);
        }).catch(error => {
            throw error;
            });
    }

    render(){
        return(
            <div className="center">
                <h1>Products</h1>
                        { this.state.prods.map(prod => 
                            <Card style={{ width: '30rem' }} className="center" key={prod.id}>
                                <Card.Body>
                                    <Card.Title>{prod.name}</Card.Title>
                                    <Card.Text>{prod.description}</Card.Text>
                                </Card.Body>
                                <Card.Img fluid src={`data:image/png;base64,${prod.photo}`} />
                                <ListGroup className="list-group-flush">
                                    <ListGroupItem>{prod.brand.name}</ListGroupItem>
                                    <ListGroupItem>{prod.price}</ListGroupItem>
                                </ListGroup>
                            </Card>
                          )
                        }
                </div>
        )
    }
}

export default Products;