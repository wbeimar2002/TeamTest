import React, {Component} from 'react';
import {Nav} from 'react-bootstrap';
import { Switch, Route, Link } from 'react-router-dom';
import  Categories  from './Categories';
import  Clients  from './Clients';
import  Products  from './Products';

class TabMenu extends Component{
    render(){
        return(
            <div>
                <div>
                    <Nav variant="tabs" defaultActiveKey="/Home">
                        <Nav.Item>
                            <Nav.Link href="/Home">Home</Nav.Link>
                        </Nav.Item>
                        <Nav.Item>
                            <Nav.Link href="/Products">Products</Nav.Link>
                        </Nav.Item>
                        <Nav.Item>
                            <Nav.Link href="/Clients">Clients</Nav.Link>
                        </Nav.Item>
                        <Nav.Item>
                            <Nav.Link href="/Categories">Categories</Nav.Link>
                        </Nav.Item>
                    </Nav>
                </div>
                <div>
                    <Switch>
                        <Route exact path='/Categories' component={Categories} />
                        <Route exact path='/Clients' component={Clients} />
                        <Route exact path='/Products' component={Products} />
                        <Route render={function () {return <p><h3>Welcome to the Alexander React Test <br></br>Please select a menu option</h3></p>}} />
                    </Switch>
                </div>
            </div>
        );
    }
}

export default TabMenu;