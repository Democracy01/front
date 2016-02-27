var speed  = 20.0;
var move;
var wantedPosition;
 
function Update () {
    if ( Input.GetMouseButtonDown ( 0 ) ) {
        var ray = Camera.main.ScreenPointToRay ( Input.mousePosition );
        var hit;
       
        if ( Physics.Raycast (ray, hit) ) {
            move = true;
            wantedPosition = hit.point + Vector3 ( 0.0, 30.0, 0.0 );
        }
    }
 
    if ( move ) {
        if ( Vector3.Distance ( transform.position, wantedPosition ) < 0.1 ) { // Give it a larger tolerance.[/b]
            transform.position = wantedPosition; // Explicitly set the position to be the end goal.[/b]
            move = false;
        }
        else {
            transform.LookAt ( wantedPosition );
            transform.Translate ( Vector3.forward *  Time.deltaTime * speed );
        }
    }
}