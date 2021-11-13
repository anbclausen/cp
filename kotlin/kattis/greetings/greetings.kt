fun main() {
    val inp = readLine()!!.toString()
    val es = inp.filter { it == 'e' }.count()
    println('h' + "e".repeat(es * 2) + 'y')
}