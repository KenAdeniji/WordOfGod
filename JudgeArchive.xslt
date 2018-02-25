<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
<!-- 
 Created:  20030630 Judge.xml
-->

<xsl:output method="html" indent="no" />
 <xsl:template match="/">
  <html>
   <body>
    <table align="center" border="1">
     <theader>
      <tr align="center"><td colspan="7">
        Sign
        (
         <a target="_blank" href="http://bible.crosswalk.com/OnlineStudyBible/bible.cgi?new=1&amp;word=Genesis+1%3A14-19%2C+Revelation+8%3A12&amp;section=0&amp;version=nkj&amp;language=en">
          Genesis 1:14-19, Revelation 8:12
         </a>
        )
      </td></tr>
      <tr align="center">
       <td>Sign</td>
       <td>ScriptureReference</td>
       <td>Captor</td>
       <td>Apostasy</td>
       <td>Judge</td>
       <td>Conquest</td>
       <td>Major/Minor</td>
      </tr>
     </theader>     
     <tbody>
      <xsl:apply-templates select="/Judge/Judge">
       <xsl:sort select="Sign" data-type="number" order="ascending" case-order="lower-first"/>
       <xsl:sort select="position()" data-type="number" order="ascending" case-order="lower-first"/> 
      </xsl:apply-templates>
     </tbody>
     <tfooter>
      <tr align="center">
       <td><a target="_blank" href="http://bible.crosswalk.com/OnlineStudyBible/bible.cgi?new=1&amp;word=Psalms+99%3A6&amp;section=0&amp;version=nkj&amp;language=en">Total</a></td>
       <td/>
       <td/>
       <td><a target="_blank" href="http://bible.crosswalk.com/OnlineStudyBible/bible.cgi?new=1&amp;word=Psalms+99%3A6&amp;section=0&amp;version=nkj&amp;language=en"><xsl:value-of select="sum(//Apostasy)"/></a></td>
       <td/>
       <td><a target="_blank" href="http://bible.crosswalk.com/OnlineStudyBible/bible.cgi?new=1&amp;word=Psalms+99%3A6&amp;section=0&amp;version=nkj&amp;language=en"><xsl:value-of select="sum(//Conquest)"/></a></td>
       <td/>
      </tr>
     </tfooter>     
    </table>
  </body>
 </html>
 </xsl:template>

 <xsl:template match="/Judge/Judge">
  <tr align="center">
   <td>
    <xsl:choose>
     <xsl:when test="ScriptureReferenceURI!=''">
      <a target="_blank" href="{ScriptureReferenceURI}">
       <xsl:value-of select="Sign"/>
      </a>
     </xsl:when>
     <xsl:otherwise>
      <xsl:value-of select="Sign"/>
     </xsl:otherwise>
    </xsl:choose>
   </td>
   <td>
    <xsl:choose>
     <xsl:when test="ScriptureReferenceURI!=''">
      <a target="_blank" href="{ScriptureReferenceURI}">
       <xsl:value-of select="ScriptureReference"/>
      </a>
     </xsl:when>
     <xsl:otherwise>
      <xsl:value-of select="ScriptureReference"/>
     </xsl:otherwise>
    </xsl:choose>
   </td>
   <td>
    <xsl:choose>
     <xsl:when test="ScriptureReferenceURI!=''">
      <a target="_blank" href="{ScriptureReferenceURI}">
       <xsl:value-of select="Captor"/>
      </a>
     </xsl:when>
     <xsl:otherwise>
      <xsl:value-of select="Captor"/>
     </xsl:otherwise>
    </xsl:choose>
   </td>
   <td>
    <xsl:choose>
     <xsl:when test="ScriptureReferenceURI!=''">
      <a target="_blank" href="{ScriptureReferenceURI}">
       <xsl:value-of select="Apostasy"/>
      </a>
     </xsl:when>
     <xsl:otherwise>
      <xsl:value-of select="Apostasy"/>
     </xsl:otherwise>
    </xsl:choose>
   </td>
   <td>
    <xsl:choose>
     <xsl:when test="ScriptureReferenceURI!=''">
      <a target="_blank" href="{ScriptureReferenceURI}">
       <xsl:value-of select="Judge"/>
      </a>
     </xsl:when>
     <xsl:otherwise>
      <xsl:value-of select="Judge"/>
     </xsl:otherwise>
    </xsl:choose>
   </td>
   <td>
    <xsl:choose>
     <xsl:when test="ScriptureReferenceURI!=''">
      <a target="_blank" href="{ScriptureReferenceURI}">
       <xsl:value-of select="Conquest"/>
      </a>
     </xsl:when>
     <xsl:otherwise>
      <xsl:value-of select="Conquest"/>
     </xsl:otherwise>
    </xsl:choose>
   </td>
   <td>
    <xsl:choose>
     <xsl:when test="ScriptureReferenceURI!=''">
      <a target="_blank" href="{ScriptureReferenceURI}">
       <xsl:value-of select="MajorMinor"/>
      </a>
     </xsl:when>
     <xsl:otherwise>
      <xsl:value-of select="MajorMinor"/>
     </xsl:otherwise>
    </xsl:choose>
   </td>
  </tr>
 </xsl:template>
</xsl:stylesheet>

<!--
Legal filter operators are:
 =    (equal) 
 !=   (not equal) 
 &lt; less than 
 &gt; greater than
-->

<!--
HTML Special Entities
Character   Meaning        Entity   Numeric
<           Less than      &lt;     &#60;
>           Greater than   &gt;     &#62;
&           Ampersand      &amp;    &#38;
'           Apostrophe     &apos;   &#39;
"           Quote          &quot;   &#34;
-->