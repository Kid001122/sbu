import "./css/forms.css"

const Entry = () => {
    return ( 
        <div className="entry">

            <h2>Add an Entry</h2>

            <form method="post">
                    
                <input id="name" type="text" placeholder="name"></input>
            
                <input id="number" type="text" placeholder="number">
                        
                    </input>

                <div className="button-container">
                    <button id="add-button">Add </button>
                    <button id="cancel-button"> Cancel </button>
                </div>
            </form>
        </div>
     );
}
 
export default Entry;