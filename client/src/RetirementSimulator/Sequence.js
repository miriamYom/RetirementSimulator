import "./Sequence.css";

function Sequence() {
    let page = 1;
    return (
        <div className="group-289334">
            <div className="group-90">
                <div>
                    <p className={page > 3 ? "text-on" : "text-off"}>חלקיות משרה</p>
                </div>
                <div>
                    <ellipse className={page > 3 ? "ellipse-on" : "ellipse-off"}>
                        {page > 3 ? "✔️" : "4"}
                    </ellipse>
                </div>
                <div>
                    <hr className={page > 2 ? "line-on" : "line-off"}></hr>
                </div>
                <div>
                    <p className={page > 3 ? "text-on" : "text-off"}>סכומים ויתרות</p>
                </div>
                <div>
                    <ellipse className={page > 2 ? "ellipse-on" : "ellipse-off"}>
                        {page > 2 ? "✔️" : "3"}
                    </ellipse>
                </div>
                <div>
                    <hr className={page > 1 ? "line-on" : "line-off"}></hr>
                </div>
                <div>
                    <p className={page > 1 ? "text-on" : "text-off"}>נתונים כלליים</p>
                </div>
                <div>
                    <ellipse className={page > 1 ? "ellipse-on" : "ellipse-off"}>
                        {page > 1 ? "✔️" : "2"}
                    </ellipse>
                </div>
                <div>
                    <hr className={page > 0 ? "line-on" : "line-off"}></hr>
                </div>
                <div>
                    <p className={page > 0 ? "text-on" : "text-off"}>סוג פנסיה</p>
                </div>
                <div>
                    <ellipse className={page > 0 ? "ellipse-on" : "ellipse-off"}>
                        {page > 0 ? "✔️" : "1"}
                    </ellipse>
                </div>
            </div>
        </div>
    );
}
export default Sequence;